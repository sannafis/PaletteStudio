using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Services;
using PaletteStudioApi.Data;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using AutoMapper.QueryableExtensions;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Repositories
{
    public class ColoursRepository : IColoursRepository
    {
        private readonly PaletteStudioDbContext _context;
        private readonly IMapper _mapper;

        public ColoursRepository(PaletteStudioDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ColourDto>> GetAllAsync()
        {
            var colours = await _context.Set<Colour>()
                .ProjectTo<ColourDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return colours;
        }

        public async Task<PagedData<ColourDto>> GetAllPagedAsync(PagingParameters pagingParameters)
        {
            // get total size of data list
            var totalSize = await _context.Set<Colour>()
                .CountAsync();

            // get items with paging parameters
            var colours = await _context.Set<Colour>()
                .Skip(pagingParameters.StartIndex)
                .Take(pagingParameters.PageSize)
                .ProjectTo<ColourDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedData<ColourDto>
            {
                Items = colours,
                PageNumber = pagingParameters.StartIndex,
                RecordNumber = pagingParameters.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task<ColourDto> CreateNormalizedAsync(ColourDto colour)
        {
            colour.HexCode = colour.HexCode.ToUpper();

            await _context.AddAsync(colour);
            await _context.SaveChangesAsync();

            // map back to dto object
            return colour;
        }

        public async Task DeleteAsync(string hex)
        {

            var colourEntity = await GetEntityAsync(hex);

            if (colourEntity == null)
            {
                throw new NotFoundException(typeof(Colour).Name, hex);
            }

            _context.Set<Colour>().Remove(colourEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string hex)
        {
            var entity = await GetAsync(hex);
            return entity != null;
        }

        public async Task<Colour?> GetEntityAsync(string? hex)
        {
            return await _context.Set<Colour>().FirstOrDefaultAsync(c => c.HexCode.ToUpper().Equals(hex.ToUpper()));
        }

        public async Task<ColourDto> GetAsync(string? hex)
        {
            var result = await _context.Set<Colour>().FirstOrDefaultAsync(c => c.HexCode.ToUpper().Equals(hex.ToUpper()));
            if (result == null)
            {
                throw new NotFoundException(typeof(Colour).Name, hex == null ? "No hex code provided" : hex);
            }

            // Map to object Dto
            return _mapper.Map<ColourDto>(result);
        }
    }
}
