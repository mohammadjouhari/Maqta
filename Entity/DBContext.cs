using Microsoft.EntityFrameworkCore;
using Entity;

namespace Entity
{
    public class DBContext : DbContext
    {
        //public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=.;database=Maqta;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
