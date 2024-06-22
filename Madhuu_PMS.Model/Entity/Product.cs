using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Madhuu_PMS.Model.Entity
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public float Rate { get; set; }

        public int CategoryId { get; set; }
        public int batchNo { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime productionDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public float quantity { get; set; }
        [NotMapped]
        public IFormFile? productImage { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public Category Category { get; set; }
    }
}
