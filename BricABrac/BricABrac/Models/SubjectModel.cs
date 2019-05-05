using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BricABrac.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Coefficient { get; set; }
        [StringLength(255)]
        public string UserIdSubject { get; set; }

        public virtual ModuleModel Module { get; set; }
        public virtual ICollection<GradeModel> Grades { get; set; } = new List<GradeModel>();

        [ForeignKey("Module")]
        public int Moduleid { get; set; }
    }
}
