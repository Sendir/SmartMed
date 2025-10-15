using medicationApi.Dtos.Medicine;
using medicationApi.Models;

namespace medicationApi.Mappers
{
    public static class MedicineMappers
    {
        public static MedicineDto ToStockDto(this Medicine medicineDtol)
        {
            return new MedicineDto
            {
                Id = medicineDtol.Id,
                Name = medicineDtol.Name,
                Quantity = medicineDtol.Quantity,
                CreatedAt = medicineDtol.CreatedAt

            };
        }

        public static Medicine ToMedicineFromCreateDto(this CreateMedicineDto medicineDto)
        {
            return new Medicine
            {
                Name = medicineDto.Name,
                Quantity = medicineDto.Quantity
            };
        }
    }
}