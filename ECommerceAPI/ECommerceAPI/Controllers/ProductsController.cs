using ECommerce.Application.Models;
using ECommerce.Application.Services;
using Hyland.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
	[Route("products")]
	public class ProductsController : ControllerBase
	{
		//private ILogger<ProductsController> _logger = null;

		private readonly ILogger<ProductsController> _logger;
		private IProductService _productService;

		public ProductsController(ILogger<ProductsController> logger, IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		[HttpGet]		
		public IActionResult GetProducts()
		{
			//var objectList = _productService.GetProducts();			
		

			return Ok("Hello");
		}

		[HttpPost]		
		public IActionResult AddProduct([FromBody] CreateProductRequest createProductRequest)
		{
			string test = Strings.GetString("STR_RC_SAVETOFILE");
			Console.WriteLine($"Converted string: {test}");

			_productService.AddProduct(createProductRequest.Name, createProductRequest.Category, createProductRequest.Description);

			return Ok(createProductRequest);
		}
	}
}
