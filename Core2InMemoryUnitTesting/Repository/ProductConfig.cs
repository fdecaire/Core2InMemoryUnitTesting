using Core2InMemoryUnitTesting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core2InMemoryUnitTesting.Repository
{
	public static class ProductConfig
	{
		public static void AddProduct(this ModelBuilder modelBuilder, string schema)
		{
			modelBuilder.Entity<Product>(entity =>
			{
				entity.ToTable("Product", schema);
				entity.Property(e => e.Name).HasColumnType("varchar(50)");

				entity.Property(e => e.Price).HasColumnType("money");

				entity.Property(e => e.Quantity).HasColumnType("int");

				entity.HasOne(d => d.StoreNavigation)
					.WithMany(p => p.Product)
					.HasForeignKey(d => d.Store)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_store_product");
				
			});
		}
	}
}
