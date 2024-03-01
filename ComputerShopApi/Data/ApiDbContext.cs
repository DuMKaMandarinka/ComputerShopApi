using ComputerShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Xml;

namespace ComputerShopApi.Data
{
    public class ApiDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Company> Companys { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<SetProduct> SetProducts { get; set; }

        public DbSet<BranchProductModel> BranchProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<DeviceInfo> DeviceInfo { get; set; }

        //public DbSet<Brand> Brands { get; set; }

        public DbSet<Models.Type> Types { get; set; }

        public DbSet<AmountSales> AmountSales { get; set; }

        public DbSet<Sales> Sales { get; set; }

        //public DbSet<Info> Info { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
          : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to postgres with connection string from app settings
        //    options.UseNpgsql(Configuration.GetConnectionString("DbConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Device>()
            //.HasMany(p => p.SetProducts)
            //.WithMany(c => c.Device);

            //modelBuilder.Entity<Info>().HasKey(u => new { u.Author, u.AuthorId });

            //modelBuilder.Entity<Info>().Property(u => u.Author).HasColumnName("Author");
            //modelBuilder.Entity<Info>().Property(u => u.Author2).HasColumnName("Author");
            //// использование Fluent API
            //base.OnModelCreating(modelBuilder);








            //modelBuilder.Entity<Devices>()
            //    .HasMany(x => x.Branches)
            //    .WithMany(x => x.Devices)
            //    .UsingEntity<BranchProductModel>();

            //modelBuilder.Entity<SetProducts>()
            //    .HasMany(x => x.Branches)
            //    .WithMany(x => x.SetProducts)
            //    .UsingEntity<BranchProductModel>();

            //modelBuilder.Entity<BranchProductModel>()
            //    .HasOne(x => x.Device)
            //    .WithOne()
            //    .HasPrincipalKey<Devices>(x => new { x.Type,x.Id})
            //    .HasForeignKey<BranchProductModel>(x => new { x.Type, x.ProductId })
            //    .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<BranchProductModel>()
            //    .HasOne(x => x.SetProduct)
            //    .WithOne()
            //    .HasPrincipalKey<SetProducts>(x => new { x.Type, x.Id })
            //    .HasForeignKey<BranchProductModel>(x => new { x.Type, x.ProductId })
            //    .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<BranchProductModel>()
            //    .HasOne(x => x.Branch)
            //    .WithOne()
            //    .HasForeignKey<BranchProductModel>(x => new { x.ProductId })
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
            .HasOne(a => a.AmountSales)
            .WithOne(a => a.Product)
            .HasForeignKey<AmountSales>(c => c.Product_Id)
            .IsRequired(false);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Branches)
                .WithMany(x => x.Products)
                .UsingEntity<BranchProductModel>();
            modelBuilder.Entity<BranchProductModel>()
                .HasOne(x => x.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BranchProductModel>()
                .HasOne(x => x.Branch)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
