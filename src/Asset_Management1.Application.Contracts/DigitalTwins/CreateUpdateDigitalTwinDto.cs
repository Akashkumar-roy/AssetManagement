using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Asset_Management1.DigitalTwins
{
    public class CreateUpdateDigitalTwinDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        public Guid ProductId { get; set; }

        public Guid BatchId { get; set; }

        [Required]
        [StringLength(128)]
        public string url { get; set; }
    }
}
