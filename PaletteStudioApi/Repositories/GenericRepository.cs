using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Contracts;
using PaletteStudioApi.Data;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PaletteStudioDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(PaletteStudioDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TResult> CreateAsync<TSource, TResult>(TSource source)
        {
            //map object to data entity type
            var entity = _mapper.Map<TEntity>(source);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            // map back to dto object
            return _mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public Task<List<TResult>> GetAllAsync<TResult>()
        {
            var items = _context.Set<TEntity>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return items;
        }

        public async Task<PagedData<TResult>> GetAllPagedAsync<TResult>(PagingParameters pagingParameters)
        {
            // get total size of data list
            var totalSize = await _context.Set<TEntity>()
                .CountAsync();

            // get items with paging parameters
            var items = await _context.Set<TEntity>()
                .Skip(pagingParameters.StartIndex)
                .Take(pagingParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedData<TResult>
            {
                Items = items,
                PageNumber = pagingParameters.StartIndex,
                RecordNumber = pagingParameters.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task<TEntity?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
            if (result == null)
            {
                throw new NotFoundException(typeof(TResult).Name, id.HasValue ? id : "Not a Valid Key");
            }            

            // Map to object Dto
            return _mapper.Map<TResult>(result);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);

            if(entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            // map source dto object to the original entity type
            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
