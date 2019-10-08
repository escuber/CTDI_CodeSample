using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTDI_Food.data.models;

namespace CTDI_Food.data.contexts
{
    public class productsContext : DbContext
    {
        public  static DbContextOptions<productsContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<productsContext>();
            builder.UseInMemoryDatabase("inst")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
        public productsContext(DbContextOptions<productsContext> options)
    : base(options)
        {
        }

        public virtual DbSet<discount> discount { get; set; }
        public virtual DbSet<productDiscount> productDiscount { get; set; }
        public virtual DbSet<product> product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }
    }
}
