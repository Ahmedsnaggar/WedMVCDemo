using WedMVCDemo.Entities.Models;

namespace WedMVCDemo.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<Store> GetStoreById(int id);
        Task<Store> AddStore(Store store);
        Task<Store> UpdateStore(Store store);
        Task DeleteStore(int id);
    }
}
