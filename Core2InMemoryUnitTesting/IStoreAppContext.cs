using System;
using Core2InMemoryUnitTesting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core2InMemoryUnitTesting
{
	public interface IStoreAppContext : IDisposable
	{
		DbSet<Product> Products { get; set; }
		DbSet<Store> Stores { get; set; }
		void SaveChanges();
	}
}
