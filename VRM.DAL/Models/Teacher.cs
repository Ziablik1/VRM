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
    public partial class Teacher: IdentityUser
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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherId { get; set; }
    }
}
