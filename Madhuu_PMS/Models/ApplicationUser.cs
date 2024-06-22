using Madhuu_PMS.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Madhuu_PMS.Web.Models
{
    public class ApplicationUser : IdentityUser     
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string UserRoleId { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public IFormFile? ProfilePicture { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}