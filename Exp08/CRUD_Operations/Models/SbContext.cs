using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Models
{
    public class SbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;database=CRUDOPERATION;trusted_connection=true;");
        }
    }
}
