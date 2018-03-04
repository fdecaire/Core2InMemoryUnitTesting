using System;
using System.Linq;
using Core2InMemoryUnitTesting;
using Core2InMemoryUnitTesting.Domain;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject
{
	public class TestDataFixture : IDisposable
	{
		public StoreAppContext Context { get; set; }

		public TestDataFixture()
		{
			var builder = new DbContextOptionsBuilder<StoreAppContext>()
				.UseInMemoryDatabase("DemoData");
			Context = new StoreAppContext(builder.Options);
		}

		public void ResetData()
		{
			var allProducts = from p in Context.Products select p;
			Context.Products.RemoveRange(allProducts);

			var allStores = from s in Context.Stores select s;
			Context.Stores.RemoveRange(allStores);

			var store = new Store
			{
				Name = "J-Foods"
			};

			Context.Stores.Add(store);
			Context.Products.Add(new Product
			{
				Name = "Rice",
				Price = 5.99m,
				Quantity = 5,
				Store = store.Id
			});
			Context.Products.Add(new Product
			{
				Name = "Bread",
				Price = 2.35m,
				Quantity = 3,
				Store = store.Id
			});

			var store2 = new Store
			{
				Name = "ToyMart"
			};
			Context.Stores.Add(store2);

			((DbContext)Context).SaveChanges();
		}

		public void Dispose()
		{

		}
	}
}
