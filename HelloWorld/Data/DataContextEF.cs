using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  public class DataContextEF: DbContext
  {
    private IConfiguration _config;
    public DbSet<MarketingProduct> MarketingProducts { get; set; }

    public DataContextEF(IConfiguration config)
    {
      _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer(
          _config.GetConnectionString("DefaultConnection")
          , options => options.EnableRetryOnFailure()
        );
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<MarketingProduct>(entity =>
      {
        entity.ToTable("Marketing.Product");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).HasColumnName("Id");
        entity.Property(e => e.Name).HasColumnName("Name");
        entity.Property(e => e.Price).HasColumnName("Price");
        entity.Property(e => e.DiscountPrice).HasColumnName("DiscountPrice");
        entity.Property(e => e.Inventory).HasColumnName("Inventory");
        entity.Property(e => e.Active).HasColumnName("Active");
        entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");
      });
    }
  }
}