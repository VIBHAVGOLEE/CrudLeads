namespace CrudLeads.Application.DTOs
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
