﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Test")]
    public partial class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Time { get; set; }
        public int? TeachertId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Question> Question { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
