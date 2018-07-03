using System;

namespace Linq.Models
{
    public class PostModel
    {
        public PostModel() { }

        public PostModel(PostModel postModel)
        {
            Id = postModel.Id;
            CreatedAt = postModel.CreatedAt;
            Body = postModel.Body;
            Likes = postModel.Likes;
            Title = postModel.Title;
            UserId = postModel.UserId;
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }
}
