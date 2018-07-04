using System;

namespace Linq.Interfaces
{
    public interface ICommentModel
    {
        string Body { get; set; }
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        int Likes { get; set; }
        int PostId { get; set; }
        int UserId { get; set; }

        string ToString();
    }
}