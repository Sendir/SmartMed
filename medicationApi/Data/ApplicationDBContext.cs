using medicationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace medicationApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        
        public DbSet<Medicine> Medicine { get; set; }
    }
}