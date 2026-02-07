using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "RoleId is required")]
        public long RoleId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
