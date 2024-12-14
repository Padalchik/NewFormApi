using Microsoft.EntityFrameworkCore;
using WebForm.Entity;

namespace WebForm
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Включаем Lazy Loading Proxies
            //optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
