using System;
using System.Collections.Generic;
using System.Text;

namespace VRM.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TQ")]
    public partial class TQ
    {
        [Key]
        public int ID { get; set; }
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionId { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
    }
}
