using System;

namespace Linq.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }
    }
}
