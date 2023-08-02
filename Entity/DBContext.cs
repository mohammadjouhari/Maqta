using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Entity;

>>>>>>> 7f5fe51 (Added my project)
namespace Entity
{
    public class DBContext : DbContext
    {
<<<<<<< HEAD
=======
        //public DBContext() { }

>>>>>>> 7f5fe51 (Added my project)
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            //optionsBuilder.UseSqlServer(@"server=.;database=HrSoultion2;Trusted_Connection=True;MultipleActiveResultSets=true");
=======
            //optionsBuilder.UseSqlServer(@"server=.;database=Maqta;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
>>>>>>> 7f5fe51 (Added my project)
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
