using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public string UserIdTodo { get; set; }
    }
}
