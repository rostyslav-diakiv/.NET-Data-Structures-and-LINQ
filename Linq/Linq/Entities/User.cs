namespace Linq.Entities
{
    using System.Collections.Generic;

    using Linq.Models;

    public class User : UserModel
    {
        public User() { }

        public User(UserModel model, IEnumerable<TodoModel> todoModels, IEnumerable<Post> posts) : base(model)
        {
            TodoModels = new List<TodoModel>(todoModels);
            Posts = new List<Post>(posts);
        }

        public User(User model, IEnumerable<TodoModel> todos) : this(model, todos, model.Posts) { }

        public List<Post> Posts { get; set; }

        public List<TodoModel> TodoModels { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"User id: {Id}, Name: {Name}";
        }
    }
}
