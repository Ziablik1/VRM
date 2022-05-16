using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRM.Presentation.Models
{
    public class AppRoleListViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
