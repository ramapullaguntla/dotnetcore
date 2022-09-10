using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Models
{
	public class CreateProductRequest
	{		
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
	}
}
