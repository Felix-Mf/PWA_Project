using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PWA_Project.Shared
{
    public class Entry
    {
        [Key]
        public int TestId { get; set; }

        [Key]
        public int QuestionId { get; set; }

        [Key]
        public int AnswerId { get; set; }

        public virtual Test Test { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
