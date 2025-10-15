namespace medicationApi.Dtos.Medicine
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}