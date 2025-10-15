using System.ComponentModel.DataAnnotations;

namespace medicationApi.Dtos.Medicine
{
    public class CreateMedicineDto
    {
        [Required(ErrorMessage = "Medication name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }
    }
}