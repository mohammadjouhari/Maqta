using Microsoft.EntityFrameworkCore;
using Entity;

namespace Entity
{
    public class DBContext : DbContext
    {
        //public DBContext()
        //{
        //}
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer(@"server=.;database=HrSoultionv3;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
