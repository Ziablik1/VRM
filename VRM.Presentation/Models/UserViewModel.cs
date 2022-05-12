namespace VRM.Presentation.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public List<SelectListItem> ApplicationRoles { get; set; }
        public string ApplicationRoleId { get; set; }
    }
}
