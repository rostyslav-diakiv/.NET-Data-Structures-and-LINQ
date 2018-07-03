namespace Linq.Entities
{
    using System.Collections.Generic;

    using Linq.Models;

    public class Post : PostModel
    {
        public Post() { }

        public Post(PostModel postModel, IEnumerable<CommentModel> comments) : base(postModel)
        {
            Comments = new List<CommentModel>(comments);
        }

        public List<CommentModel> Comments { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Post id: {Id}, Title: {Title}, CreatedAt: {CreatedAt}";
        }
    }
}
