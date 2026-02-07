using System.ComponentModel.DataAnnotations;

namespace CrudLeads.Application.DTOs
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
