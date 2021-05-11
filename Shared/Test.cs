using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PWA_Project.Shared
{
    public class Test
    {
        public Test()
        {
            Question = new HashSet<Question>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titel { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Date_min { get; set; }

        [Required]
        public DateTime Date_max { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
