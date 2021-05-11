using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PWA_Project.Shared
{
    public class Input
    {
        public Input()
        {
            Test = new HashSet<Test>();
            Question = new HashSet<Question>();
            Answer = new HashSet<Answer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int AnswerId { get; set; }

        public virtual ICollection<Test> Test { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
