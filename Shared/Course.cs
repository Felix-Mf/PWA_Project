using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PWA_Project.Shared
{
    public class Course
    {
        public Course()
        {
            Test = new HashSet<Test>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titel { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Test> Test { get; set; }
    }
}
