using Microsoft.EntityFrameworkCore;
using Paviza_Zapocet.Data.Model;

namespace Paviza_Zapocet.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
         
        }

        public DbSet<CompanyKeys> CompanyKeys { get; set; }
        public DbSet<PurchaseOrderHeaders> PurchaseOrderHeaders { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
    }
}
