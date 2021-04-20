using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PWA_Project.Shared
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public Boolean Correct { get; set; }

        public virtual Question Question { get; set; }
    }
}
