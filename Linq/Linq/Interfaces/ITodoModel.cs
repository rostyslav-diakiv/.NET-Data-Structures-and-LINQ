using System;

namespace Linq.Interfaces
{
    public interface ITodoModel
    {
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        bool IsComplete { get; set; }
        string Name { get; set; }
        int UserId { get; set; }

        string ToString();
    }
}