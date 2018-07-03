using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
