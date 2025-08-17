using Microsoft.EntityFrameworkCore;
using CSharpCode.DTO;

namespace CSharpCode.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<InsuranceData> InsuranceApplications { get; set; }
    }
}
