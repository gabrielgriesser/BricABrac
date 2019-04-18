using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class ModuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolYear { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }
}
