using System;

namespace Linq.Interfaces
{
    public interface IPostModel
    {
        string Body { get; set; }
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        int Likes { get; set; }
        string Title { get; set; }
        int UserId { get; set; }
    }
}