using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class UserUpdateDto
    {
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        public long? RoleId { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
