using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    /// <summary>
    /// Represents a grade for a student
    /// </summary>
    public class StudentGradeModel
    {
        public List<ModuleModel> Modules { get; set; }
        public List<SubjectModel> Subjects { get; set; }
        public List<GradeModel> Grades { get; set; }
    }
}
