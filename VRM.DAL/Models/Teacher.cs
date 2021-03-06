using System;
using System.Collections.Generic;
using System.Text;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    [Table("Teacher")]
    public partial class Teacher
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int AdminId { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
