using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Asset_Management1.DigitalTwins
{
    public class DigitalTwin : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ProductId { get; set; }

        public Guid BatchId  { get; set; }

        public string url { get; set; }
    }
}
