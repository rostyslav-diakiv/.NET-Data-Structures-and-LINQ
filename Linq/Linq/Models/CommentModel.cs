using System;

namespace Linq.Models
{
    using Linq.Interfaces;

    public class CommentModel : ICommentModel
    {
        public CommentModel() { }


        public int Id { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Comment id: {Id}, Body: {Body}, Body Length: {Body.Length}, Likes: {Likes}, Created at: {CreatedAt}";
        }
    }
}
