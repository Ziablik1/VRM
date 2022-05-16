namespace VRM.Presentation.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
