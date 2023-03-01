using Core.Entities;

namespace Core.Interfaces.Persistence
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        ///     Get one item by Id
        /// </summary>
        Task<T> GetItemAsync(string id);

        Task AddItemAsync(T item);
        
        Task UpdateItemAsync(string id, T item);
        
        Task DeleteItemAsync(string id);

        /// <summary>
        ///     Get items by providing a query string.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync(string queryString);
    }
}
