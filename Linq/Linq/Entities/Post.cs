using System;

namespace Linq.Entities
{
    using System.Collections.Generic;

    using Linq.Models;

    public class Post
    {
        public Post() { }

        public Post(PostModel postModel, IEnumerable<CommentModel> comments)
        {
            Id = postModel.Id;
            CreatedAt = postModel.CreatedAt;
            Body = postModel.Body;
            Likes = postModel.Likes;
            Title = postModel.Title;
            UserId = postModel.UserId;
            Comments = new List<CommentModel>(comments);
        }


        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public List<CommentModel> Comments { get; set; }
    }
}
