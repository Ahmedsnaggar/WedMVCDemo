using System.Linq.Expressions;
using WedMVCDemo.Entities.Models;

namespace WedMVCDemo.Interfaces
{
    public interface IGenericRepository<T> where T :  MainModel
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, string[] incules=null);
        Task<T> GetItemAsync(Expression<Func<T, bool>> expression = null, string[] incules = null);
        Task<T> GetByIdAsync(int id);
        Task<T> AddItemAsync(T item);
        Task<T> UpdateItemAsync(T item);
        Task DeleteItemAsync(int id);
    }
}
