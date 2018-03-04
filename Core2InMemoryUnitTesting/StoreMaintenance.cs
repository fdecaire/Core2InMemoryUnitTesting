using System.Linq;

namespace Core2InMemoryUnitTesting
{
    public class StoreMaintenance
    {
	    private readonly IStoreAppContext _storeAppContext;

	    public StoreMaintenance(IStoreAppContext storeAppContext)
	    {
		    _storeAppContext = storeAppContext;
	    }

	    public void DeleteStore(string storeName)
	    {
		    var storeList = (from s in _storeAppContext.Stores
			    where s.Name == storeName
			    select s).FirstOrDefault();

		    if (storeList != null)
		    {
			    _storeAppContext.Stores.Remove(storeList);
			    _storeAppContext.SaveChanges();
		    }
	    }
    }
}
