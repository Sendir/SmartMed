using medicationApi.Data;
using medicationApi.Interfaces;
using medicationApi.Models;
using medicationApi.Query.Logic;
using medicationApi.QueryOptions;
using Microsoft.EntityFrameworkCore;

namespace medicationApi.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public MedicineRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<Medicine>> GetAllAsync(QueryObject query)
        {
            var medicines = _dBContext.Medicine.AsQueryable()
            .ApplyFiltering(query)
            .ApplySorting(query)
            .ApplyPaging(query);

            return await medicines.ToListAsync();
        }

        public async Task<Medicine> CreateAsync(Medicine medicineModel)
        {
            await _dBContext.AddAsync(medicineModel);
            await _dBContext.SaveChangesAsync();
            return medicineModel;
        }

        public async Task<Medicine?> DeleteAsync(int id)
        {
            var medicineModel = await _dBContext.Medicine.FirstOrDefaultAsync(m => m.Id == id);

            if (medicineModel == null)
            {
                return null;
            }

            _dBContext.Medicine.Remove(medicineModel);
            await _dBContext.SaveChangesAsync();
            return medicineModel;
        }
    }
}