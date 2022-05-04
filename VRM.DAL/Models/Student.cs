using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student: IdentityUser
    {
        [Column(Order = 0)]
        [StringLength(50)]
        public string Username { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
    }
}
