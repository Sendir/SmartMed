using medicationApi.Dtos.Medicine;
using medicationApi.Interfaces;
using medicationApi.Mappers;
using medicationApi.QueryOptions;
using Microsoft.AspNetCore.Mvc;


namespace medicationApi.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicine([FromQuery] QueryObject query)
        {
            var medicinesModel = await _medicineRepository.GetAllAsync(query);
            var medicineDto = medicinesModel.Select(m => m.ToStockDto());

            return Ok(medicineDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine([FromBody] CreateMedicineDto medicineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var medicineModel = medicineDto.ToMedicineFromCreateDto();
            await _medicineRepository.CreateAsync(medicineModel);

            return Ok(medicineModel.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            var medicineModel = await _medicineRepository.DeleteAsync(id);

            if (medicineModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
