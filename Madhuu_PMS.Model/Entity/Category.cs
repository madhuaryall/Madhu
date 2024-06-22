using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madhuu_PMS.Model.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
