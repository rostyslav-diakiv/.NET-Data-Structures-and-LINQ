using System;

namespace Linq.Models
{
    using Linq.Interfaces;

    public class TodoModel : ITodoModel
    {
        public TodoModel() { }

        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, is completed: {IsComplete}";
        }
    }
}
