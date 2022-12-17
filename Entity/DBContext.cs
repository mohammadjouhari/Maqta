using Microsoft.EntityFrameworkCore;
namespace Entity
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=.;database=HrSoultion2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
