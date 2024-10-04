using MagicEye2.RichUI;
using MagicEye2.RichUI.Models;
using Microsoft.EntityFrameworkCore;


//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MagicEye2.RichUI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<MaestroTBeneficiario> MaestroTBeneficiarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }
    }
}

