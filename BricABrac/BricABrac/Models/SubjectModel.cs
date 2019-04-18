using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coefficient { get; set; }

        public virtual ModuleModel Module { get; set; }
        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();
    }
}
