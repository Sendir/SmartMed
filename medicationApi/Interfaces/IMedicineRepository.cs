using medicationApi.Models;
using medicationApi.QueryOptions;

namespace medicationApi.Interfaces
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync(QueryObject query);
        Task<Medicine> CreateAsync(Medicine medicineModel);
        Task<Medicine?> DeleteAsync(int id);
    }
}