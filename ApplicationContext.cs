using Microsoft.EntityFrameworkCore;


namespace HW_27_08_1_
{
    internal class ApplicationContext:DbContext
    {
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Trains> Trains { get; set; }       

    }
}
