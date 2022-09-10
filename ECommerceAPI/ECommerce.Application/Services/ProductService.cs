using ECommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
	internal class ProductService
	{
		private IProductService _productService;
		public ProductService(IProductService productService)
		{
			_productService = productService;
		}

		public void AddProduct(string name, string category, string description)
		{
			_productService.AddProduct(name, category, description);
		}
	}

	public interface IProductService
	{
		void AddProduct(string name, string category, string description);

		List<ProductModel> GetProducts();

		void UpdateProduct();
	}
}
