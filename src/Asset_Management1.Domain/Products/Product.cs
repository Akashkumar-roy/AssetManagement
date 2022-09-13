using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Asset_Management1.Products
{
	public class Product : AuditedAggregateRoot<Guid>
	{
		public string Name { get; set; }

		public DateTime PublishDate { get; set; }

		public float Price { get; set; }
	}
}
