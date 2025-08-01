using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD
{
    public class HRmanagementDbContext:DbContext
    {
        public HRmanagementDbContext(DbContextOptions options ):base (options)
        {
            
        }
        public DbSet<Department> departments { get; set; }

        public DbSet<Employee> employees { get; set; }

    }
}
