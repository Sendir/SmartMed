using medicationApi.Models;
using medicationApi.QueryOptions;
using medicationApi.Query.Logic;

namespace medicationApi.Tests
{
    public class MedicineRepositoryTests
    {
        private List<Medicine> GetFakeMedicines()
        {
            return
            [
                new Medicine { Id = 1, Name = "Aspirin", Quantity = 10 },
            new Medicine { Id = 2, Name = "Panadol", Quantity = 20 },
            new Medicine { Id = 3, Name = "Zyrtec", Quantity = 5 }
            ];
        }

        [Fact]
        public void ApplyFiltering_ShouldFilterByName()
        {
            // Arrange
            var query = new QueryObject { Name = "Aspi" };
            var medicines = GetFakeMedicines().AsQueryable();

            // Act
            var result = medicines.ApplyFiltering(query).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Aspirin", result.First().Name);
        }

        [Fact]
        public void ApplySorting_ShouldSortByQuantityDescending()
        {
            // Arrange
            var query = new QueryObject { SortBy = "quantity", IsDescending = true };
            var medicines = GetFakeMedicines().AsQueryable();

            // Act
            var result = medicines.ApplySorting(query).ToList();

            // Assert
            Assert.Equal(20, result.First().Quantity);
        }
    }
}