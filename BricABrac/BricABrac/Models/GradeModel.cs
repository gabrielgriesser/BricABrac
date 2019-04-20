using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BricABrac.Models
{
    public class GradeModel
    {
        public int Id { get; set; }
        public decimal Grade { get; set; }
        public decimal Coefficient { get; set; }
        public string UserIdGrade { get; set; }

        public virtual SubjectModel Subject { get; set; }

        [ForeignKey("Subject")]
        public int Subjectid { get; set; }
    }
}
