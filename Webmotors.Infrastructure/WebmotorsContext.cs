using Microsoft.EntityFrameworkCore;
using Webmotors.Domain.Models;

namespace Webmotors.Infrastructure
{
    public class WebmotorsContext :DbContext
    {
        public WebmotorsContext() : base()
        {
            Database.EnsureCreated();
        }

        public WebmotorsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ad> Ads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source = teste_webmotors.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(e =>
            {
                e.ToTable("tb_AnuncioWebmotors", schema: "teste_webmotors");

                e.HasKey(p => p.ID);

                e.Property(p => p.Make).HasColumnName("marca").HasColumnType("varchar").HasMaxLength(45).IsRequired();
                e.Property(p => p.Model).HasColumnName("modelo").HasColumnType("varchar").HasMaxLength(45).IsRequired();
                e.Property(p => p.Version).HasColumnName("versao").HasColumnType("varchar").HasMaxLength(45).IsRequired();
                e.Property(p => p.Year).HasColumnName("ano").HasColumnType("int").IsRequired();
                e.Property(p => p.Mileage).HasColumnName("quilometragem").HasColumnType("int").IsRequired();
                e.Property(p => p.Note).HasColumnName("observacao").HasColumnType("text").IsRequired();
            });
        }
    }
}
