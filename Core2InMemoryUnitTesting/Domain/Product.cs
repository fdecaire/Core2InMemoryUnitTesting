namespace Core2InMemoryUnitTesting.Domain
{
	public class Product
	{
		public int Id { get; set; }
		public int Store { get; set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public int Quantity { get; set; }

		public virtual Store StoreNavigation { get; set; }
	}
}
