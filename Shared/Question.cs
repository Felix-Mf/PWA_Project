using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PWA_Project.Shared
{
    public class Question
    {
        public Question()
        {

            Answer = new HashSet<Answer>();
        }

        [Key]
        public int Id { get; set; }

        public int TestId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
    }
}
