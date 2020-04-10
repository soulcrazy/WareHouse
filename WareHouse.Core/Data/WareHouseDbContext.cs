using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WareHouse.Core.Helper;
using WareHouse.Entity;

namespace WareHouse.Core.Data
{
    public class WareHouseDbContext : DbContext
    {
        public WareHouseDbContext()
        {
        }

        public WareHouseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsType> GoodsType { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<StorageRegion> StorageRegion { get; set; }
        public DbSet<GoodsStorage> GoodsStorage { get; set; }
        public DbSet<GoodsLeave> GoodsLeave { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.UseMySql(ConfigHelper.GetConnectString());
        }
    }
}