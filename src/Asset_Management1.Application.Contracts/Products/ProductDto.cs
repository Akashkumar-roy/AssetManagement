using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Asset_Management1.Products
{
	public class ProductDto : AuditedEntityDto<Guid>
	{
		public string Name { get; set; }

		public DateTime PublishDate { get; set; }

		public float Price { get; set; }
	}
}
