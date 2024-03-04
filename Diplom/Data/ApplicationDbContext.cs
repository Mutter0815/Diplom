using Microsoft.EntityFrameworkCore;
using Diplom.Models;
namespace Diplom.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

    }
}
