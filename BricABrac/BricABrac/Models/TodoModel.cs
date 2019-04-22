using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = "PageModel in C#";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}
