using MagicEye2.Services.BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace MagicEye2.Services.BackEndAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<VersionSecaf> VersionSecafs { get; set; }
        public DbSet<Proceso> Procesos {  get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
