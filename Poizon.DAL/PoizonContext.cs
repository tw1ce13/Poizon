using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poizon.Domain.Models;

namespace Poizon.DAL
{
	public class PoizonContext : DbContext
	{

        private IConfiguration Configuration;
        public PoizonContext()
        {

        }


        public PoizonContext(DbContextOptions<PoizonContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Default"));
        }



        public DbSet<Basket> Baskets { get; set;}
		public DbSet<Cloth> Clothes { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<User> Users { get; set; }
	}
}

