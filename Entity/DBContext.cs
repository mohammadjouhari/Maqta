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
           // optionsBuilder.UseSqlServer(@"server=.;database=Maqta;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        // FluentAPi;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Employee>()
           //.HasOne<EmployeeBank>(s => s.Bank)
           //.WithOne(ad => ad.Employee)
           //.HasForeignKey<EmployeeBank>(ad => ad.EmployeeId);

        }


        public DbSet<Employee> Employee { get; set; }
    }
}
