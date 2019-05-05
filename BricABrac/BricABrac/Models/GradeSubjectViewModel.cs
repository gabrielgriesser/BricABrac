using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class GradeSubjectViewModel
    {
        public GradeModel Grade { get; set; }
        public List<SubjectModel> SubjectList { get; set; }
    }
}
