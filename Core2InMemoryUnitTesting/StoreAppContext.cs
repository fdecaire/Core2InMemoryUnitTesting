using Core2InMemoryUnitTesting.Domain;
using Core2InMemoryUnitTesting.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core2InMemoryUnitTesting
{
	public class StoreAppContext : DbContext, IStoreAppContext
	{
		public StoreAppContext(DbContextOptions<StoreAppContext> options)
		: base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Store> Stores { get; set; }

		public new void SaveChanges()
		{
			base.SaveChanges();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddProduct("dbo");
			modelBuilder.AddStore("dbo");
		}
	}
}
