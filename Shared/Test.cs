using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PWA_Project.Shared
{
    public class Test
    {
        public Test()
        {

            Question = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Description { get; set; }

        public DateTime Date_min { get; set; }

        public DateTime Date_max { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
