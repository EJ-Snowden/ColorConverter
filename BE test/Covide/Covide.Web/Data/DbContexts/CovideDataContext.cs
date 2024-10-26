using Covide.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covide.Web.Data.DbContexts
{
    public class CovideDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Data.db");
        }

        public DbSet<ColorCode> ColorCodes { get; set; }
    }
}
