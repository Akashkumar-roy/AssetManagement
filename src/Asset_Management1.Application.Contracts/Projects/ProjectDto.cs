using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Asset_Management1.Projects
{
	public class ProjectDto : AuditedEntityDto<Guid>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string url { get; set; }
	}
}