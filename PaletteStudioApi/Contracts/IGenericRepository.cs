using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);

        Task<List<TEntity>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();

        Task<PagedData<TResult>> GetAllPagedAsync<TResult>(PagingParameters pagingParameters);

        Task<TEntity> CreateAsync(TEntity entity);
        Task<TResult> CreateAsync<TSource, TResult>(TSource source);

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync<TSource>(int id, TSource source);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);
    }

}
