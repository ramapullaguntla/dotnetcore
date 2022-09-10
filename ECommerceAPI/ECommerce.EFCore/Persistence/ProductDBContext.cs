using ECommerce.Application.Services;
using ECommerce.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ECommerce.Application.Models;

namespace ECommerce.Infrastructure.Persistence
{
	internal class ProductDBContext : IProductService
	{
		private ECommerceContext _context;
		public ProductDBContext(ECommerceContext eCommerceContext)
		{
			_context = eCommerceContext;
		}

		public void AddProduct(string name, string category, string description)
		{
			//Product product = new Product()
			//{
			//	Name = name,
			//	Category = category,
			//	Description = description
			//};
			//_context.Products.Add(product);

			//_context.SaveChanges();

			//Call WCF Service.
			
		}

	}

		public List<ProductModel> GetProducts()
		{
			var products = (from eachProduct in _context.Products
						   orderby eachProduct.Name
						   select eachProduct.ToModel()).ToList();

			return products;
		}

		public void UpdateProduct()
		{
			throw new NotImplementedException();
		}
		
	}
}
