using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebApiTest.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }
        public DbSet<Car> CarItems { get; set; } = null!;
    }
}
