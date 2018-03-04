using System.Linq;
using Core2InMemoryUnitTesting;
using Xunit;

namespace XUnitTestProject
{
	public class ProductTests : IClassFixture<TestDataFixture>
	{
		private readonly StoreAppContext _storeAppContext;
		private readonly TestDataFixture _fixture;

		public ProductTests(TestDataFixture fixture)
		{
			_fixture = fixture;
			_storeAppContext = fixture.Context;
		}

		private void ResetRecords()
		{
			_fixture.ResetData();
		}

		[Fact]
		public void ItemIsInStock()
		{
			// Arrange
			ResetRecords();
			var inventory = new Inventory(_storeAppContext);

			// Act
			var result = inventory.InStock("J-Foods", "Rice");

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void ItemIsNotInStock()
		{
			// Arrange
			ResetRecords();
			var inventory = new Inventory(_storeAppContext);

			// Act
			var result = inventory.InStock("J-Foods", "Crackers");

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void InventoryTotalTest1()
		{
			// Arrange
			ResetRecords();
			var inventory = new Inventory(_storeAppContext);

			// Act
			var result = inventory.InventoryTotal("J-Foods");

			// Assert
			Assert.Equal(37m, result);
		}

		[Fact]
		public void InventoryTotalEmptyStore()
		{
			// Arrange
			ResetRecords();
			var inventory = new Inventory(_storeAppContext);

			// Act
			var result = inventory.InventoryTotal("ToyMart");

			// Assert
			Assert.Equal(0m, result);
		}

		[Fact]
		public void InventoryDeleteStoreViolationTest()
		{
			// Arrange
			ResetRecords();
			var storeMaintenance = new StoreMaintenance(_storeAppContext);

			// Act
			storeMaintenance.DeleteStore("J-Foods");

			// Assert
			var storeResults = from s in _storeAppContext.Stores where s.Name == "J-Foods" select s;
			Assert.Empty(storeResults);

			// test for empty product list
			var productResults = from p in _storeAppContext.Products
				join s in _storeAppContext.Stores on p.Store equals s.Id
				where s.Name == "J-Foods"
				select p;

			Assert.Empty(productResults);
		}
	}
}
