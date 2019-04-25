using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    /// <summary>
    /// Class represents a Subet module
    /// </summary>
    public class SubjectModuleViewModel
    {
        public SubjectModel Subject { get; set; }
        public List<ModuleModel> ModuleList { get; set; }
    }
}
