using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Contracts;
using PaletteStudioApi.Data;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Repositories
{
    public class PalettesRepository : GenericRepository<Palette>, IPalettesRepository
    {
        private readonly PaletteStudioDbContext _context;
        private readonly IMapper _mapper;

        public PalettesRepository(PaletteStudioDbContext context, IMapper mapper) : base(context,mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<PaletteReadOnlyDto> GetIncludeColours(int id)
        {
            var palette = await _context.Set<Palette>()
                .Include(p => p.ColourGroups)
                .ThenInclude(cg => cg.ForegroundColours)
                .FirstOrDefaultAsync(p=>p.Id == id);

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
