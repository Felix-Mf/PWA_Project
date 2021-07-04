using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PWA_Project.Shared
{
    public class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
    }
}
