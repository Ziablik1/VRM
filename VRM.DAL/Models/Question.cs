using System;
using System.Collections.Generic;
using System.Text;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Question")]
    public partial class Question
    {
        [Column("Question")]
        [Required]
        [StringLength(500)]
        public string QuestionString { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionId { get; set; }
        public ICollection<Answer> Answer { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
    }
}
