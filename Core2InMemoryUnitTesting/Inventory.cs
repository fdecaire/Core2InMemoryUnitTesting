using System.Linq;

namespace Core2InMemoryUnitTesting
{
    public class Inventory
    {
	    private readonly IStoreAppContext _storeAppContext;

	    public Inventory(IStoreAppContext storeAppContext)
	    {
		    _storeAppContext = storeAppContext;
	    }

	    public bool InStock(string storeName, string productName)
	    {
		    var totalItems = (from p in _storeAppContext.Products
			    join s in _storeAppContext.Stores on p.Store equals s.Id
			    where p.Name == productName &&
			          s.Name == storeName
			    select p.Quantity).Sum();

			return totalItems > 0;
	    }

	    public decimal InventoryTotal(string storeName)
	    {
		    var totalCostOfInventory = (from p in _storeAppContext.Products
			    join s in _storeAppContext.Stores on p.Store equals s.Id
			    where s.Name == storeName
			    select p.Price * p.Quantity).Sum();

		    return totalCostOfInventory ?? 0;
	    }
    }
}
