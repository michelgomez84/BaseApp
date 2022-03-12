using DataModel;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    //public class ApplicationDbContext : IdentityDbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {
    //    }
    //}

    //ApiAuthorizationDbContext IdentityDbContext
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        //private readonly string conString;
        //public ApplicationDbContext(string connectionString) : base()
        //{
        //    conString = connectionString;            
        //}

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //    : base(options)
        //{
        //}

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(conString);
            //}

            //lazy loading
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.LProducts)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.LProducts)
                .WithOne(e => e.PurchaseOrder)
                .HasForeignKey(e => e.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PurchaseOrderProduct>()
                .HasOne(e => e.Product)
                .WithOne()
                .HasForeignKey<PurchaseOrderProduct>(e => e.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }


    }
}
