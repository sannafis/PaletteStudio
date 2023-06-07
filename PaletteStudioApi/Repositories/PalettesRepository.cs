using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Services;
using PaletteStudioApi.Data;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Authentication;
using PaletteStudioApi.Models.Paging;
using PaletteStudioApi.Static;

namespace PaletteStudioApi.Repositories
{
    public class PalettesRepository : IPalettesRepository
    {
        private readonly PaletteStudioDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthRepository _authRepository;

        public PalettesRepository(PaletteStudioDbContext context, IMapper mapper, UserManager<User> userManager, IAuthRepository authRepository)
        {
            this._context = context;
            this._mapper = mapper;
            this._userManager = userManager;
            this._authRepository = authRepository;
        }

        public async Task<PaletteReadOnlyDto> GetIncludeColoursAsync(int id)
        {
            // get user
            string userId = await _authRepository.CurrentUser();
            var user = await _userManager.FindByIdAsync(userId);

            var palette = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.UserId!.Equals(user.Id))
                .FirstOrDefaultAsync(p => p.Id == id);

            if (palette == null) // palette does not exist
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            return _mapper.Map<PaletteReadOnlyDto>(palette);
        }

        private async Task<Palette> GetEntityAsync(int id)
        {
            // get user
            string userId = await _authRepository.CurrentUser();
            var user = await _userManager.FindByIdAsync(userId);

            var palette = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.UserId!.Equals(user.Id))
                .FirstOrDefaultAsync(p => p.Id == id);

            if (palette == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            return palette;
        }

        public async Task<List<PaletteReadOnlyDto>> GetAllIncludeColoursAsync()
        {
            // get user
            string userId = await _authRepository.CurrentUser();
            var user = await _userManager.FindByIdAsync(userId);

            return await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.UserId!.Equals(user.Id))
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedData<PaletteReadOnlyDto>> GetAllPagedIncludeColoursAsync(PagingParameters pagingParameters)
        {
            // get user
            string userId = await _authRepository.CurrentUser();
            var user = await _userManager.FindByIdAsync(userId);

            // get total size of data list
            var totalSize = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.UserId!.Equals(user.Id))
                .CountAsync();

            // get items with paging parameters
            var items = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.UserId!.Equals(user.Id))
                .Skip((pagingParameters.PageNumber-1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedData<PaletteReadOnlyDto>
            {
                Items = items,
                PageNumber = pagingParameters.PageNumber,
                PageSize = pagingParameters.PageSize,
                TotalPages = (Int32)Math.Ceiling((Decimal)totalSize / (Decimal)pagingParameters.PageSize),
            TotalCount = totalSize
            };
        }

        public async Task UpdateFullAsync(int id, PaletteUpdateDto paletteUpdateDto)
        {
            var paletteEntity = await GetEntityAsync(id);

            if (paletteEntity == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            // map source dto object to the original entity type
            _mapper.Map(paletteUpdateDto, paletteEntity);
            _context.Update(paletteEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaletteReadOnlyDto> CreateAsync(PaletteCreateDto paletteDto)
        {

            // get user
            string userId = await _authRepository.CurrentUser();
            var user = await _userManager.FindByIdAsync(userId);

            //map dto to palette entity
            var paletteEntity = _mapper.Map<Palette>(paletteDto);

            user.Palettes.Add(paletteEntity);
            await _context.SaveChangesAsync();

            // map back to dto object
            return _mapper.Map<PaletteReadOnlyDto>(paletteEntity);
        }

        public async Task<List<PaletteReadOnlyDto>> PublicGetAllAsync()
        {
            // Get all palettes (public)
            return await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.Privacy.Equals(PrivacySetting.Public))
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedData<PaletteReadOnlyDto>> PublicGetAllPagedAsync(PagingParameters pagingParameters)
        {
            // Get all palettes paged (public)

            // get total size of data list
            var totalSize = await _context.Set<Palette>()
                .Where(p => p.Privacy.Equals(PrivacySetting.Public))
                .CountAsync();

            // get items with paging parameters
            var items = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p => p.Privacy.Equals(PrivacySetting.Public))
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedData<PaletteReadOnlyDto>
            {
                Items = items,
                PageNumber = pagingParameters.PageNumber,
                PageSize = pagingParameters.PageSize,
                TotalCount = (Int32)Math.Ceiling((Decimal)(totalSize / pagingParameters.PageSize)),
            };
        }

        public async Task DeleteAsync(int id)
        {
            var paletteEntity = await GetEntityAsync(id);

            if (paletteEntity == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            _context.Set<Palette>().Remove(paletteEntity!);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity != null;
        }
    }
}
