using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Asset_Management1.Products
{
	public class CreateUpdateProductDto
	{
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}
