using System;
using System.Collections.Generic;
using System.Text;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Answer")]
    public partial class Answer
    {
        [Column("Answer")]
        [Required]
        [StringLength(500)]
        public string Answer1 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnswerId { get; set; }

        public int? QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
