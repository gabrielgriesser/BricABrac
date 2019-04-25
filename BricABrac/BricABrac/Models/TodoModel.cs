using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    /// <summary>
    /// Class represents a "Todo"
    /// a "Todo" has an Id, a Todo (the message) and an UserIdTodo (who wrote the message)
    /// </summary>
    public class TodoModel
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public string UserIdTodo { get; set; }
    }
}
