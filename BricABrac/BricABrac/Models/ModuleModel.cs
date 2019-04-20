using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BricABrac.Models
{
    public class ModuleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int SchoolYear { get; set; }
        public string UserIdModule { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }
}
