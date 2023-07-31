using Microsoft.EntityFrameworkCore;
using Poizon.Domain.Models;
namespace Poizon.DAL;

public class PoizonContext : DbContext
{

    public PoizonContext()
    {

    }
    public PoizonContext(DbContextOptions<PoizonContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=83.220.174.78;Port=5432;Database=poizon;Username=poizon;Password=tishaShop;");
        }
    }


    

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Clothes> Clothes { get; set; }
    public DbSet<Discounts> Discounts { get; set; }
    public DbSet<Promocode> Promocodes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderClothes> OrderClothes { get; set; }
    public DbSet<Sex> Sexes { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInfo> UsersInfo { get; set; }
    public DbSet<SubSubCategory> SubSubCategories { get; set; }
    
}

