using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Asset_Management1.DigitalTwins
{
    public class DigitalTwinDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ProductId { get; set; }

        public Guid BatchId { get; set; }

        public string url { get; set; }
    }
}
