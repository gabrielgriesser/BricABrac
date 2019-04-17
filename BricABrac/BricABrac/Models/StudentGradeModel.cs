using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class StudentGradeModel
    {
        public List<Modules> Modules { get; set; }
        public List<Subjects> Subjects { get; set; }
        public List<Grades> Grades { get; set; }
    }

    public class Modules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolYear { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; } = new List<Subjects>();
    }

    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coefficient { get; set; }

        public virtual Modules Module { get; set; }
        public virtual ICollection<Grades> Grades { get; set; } = new List<Grades>();
    }

    public class Grades
    {
        public int Id { get; set; }
        public decimal Grade { get; set; }
        public decimal Coefficient { get; set; }

        public virtual Subjects Subject { get; set; }
    }

}
