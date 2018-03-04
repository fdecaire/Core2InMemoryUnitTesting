using Core2InMemoryUnitTesting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core2InMemoryUnitTesting.Repository
{
	public static class StoreConfig
	{
		public static void AddStore(this ModelBuilder modelBuilder, string schema)
		{
			modelBuilder.Entity<Store>(entity =>
			{
				entity.ToTable("Store", schema);
				entity.Property(e => e.Address).HasColumnType("varchar(50)");
				entity.Property(e => e.Name).HasColumnType("varchar(50)");
				entity.Property(e => e.State).HasColumnType("varchar(50)");
				entity.Property(e => e.Zip).HasColumnType("varchar(50)");
			});
		}
	}
}
