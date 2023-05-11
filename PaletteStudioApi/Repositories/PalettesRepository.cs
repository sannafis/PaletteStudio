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
using System.Security.Claims;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace PaletteStudioApi.Repositories
{
    public class PalettesRepository : GenericRepository<Palette>, IPalettesRepository
    {
        private readonly PaletteStudioDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PalettesRepository(PaletteStudioDbContext context, IMapper mapper, UserManager<User> userManager) : base(context,mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<PaletteReadOnlyDto> GetIncludeColours(int id, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var palette = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Where(p=>p.UserId!.Equals(user.Id))
                .FirstOrDefaultAsync(p=>p.Id == id);

            throw new NotFoundException(typeof(Palette).Name, user.Id);

            if (palette == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            return _mapper.Map<PaletteReadOnlyDto>(palette);
        }

        public async Task<Palette> GetEntityIncludeColours(int id)
        {
            var palette = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if (palette == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            return palette;
        }

        public async Task<List<PaletteReadOnlyDto>> GetAllIncludeColours()
        {
            return await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        
        public async Task<PagedData<PaletteReadOnlyDto>> GetAllPagedIncludeColours(PagingParameters pagingParameters)
        {
            // get total size of data list
            var totalSize = await _context.Set<Palette>()
                .CountAsync();

            // get items with paging parameters
            var items = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .Skip(pagingParameters.StartIndex)
                .Take(pagingParameters.PageSize)
                .ProjectTo<PaletteReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedData<PaletteReadOnlyDto>
            {
                Items = items,
                PageNumber = pagingParameters.StartIndex,
                RecordNumber = pagingParameters.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task UpdateFullAsync(int id, PaletteUpdateDto paletteUpdateDto)
        {
            var paletteEntity = await GetEntityIncludeColours(id);

            if (paletteEntity == null)
            {
                throw new NotFoundException(typeof(Palette).Name, id);
            }

            // map source dto object to the original entity type
            _mapper.Map(paletteUpdateDto, paletteEntity);
            _context.Update(paletteEntity);
            await _context.SaveChangesAsync();
        }
    }
}
