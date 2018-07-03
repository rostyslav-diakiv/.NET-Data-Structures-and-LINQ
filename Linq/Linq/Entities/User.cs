namespace Linq.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Linq.Models;

    public class User
    {
        public User() { }

        public User(UserModel model, IEnumerable<TodoModel> todoModels)
        {
            Id = model.Id;
            CreatedAt = model.CreatedAt;
            Name = model.Name;
            Email = model.Email;
            Avatar = model.Avatar;
            TodoModels = new List<TodoModel>(todoModels);
        }

        public User Initialize(UserModel model, IEnumerable<TodoModel> todoModels)
        {
            Id = model.Id;
            CreatedAt = model.CreatedAt;
            Name = model.Name;
            Email = model.Email;
            Avatar = model.Avatar;
            TodoModels = new List<TodoModel>(todoModels);

            return this;
        }

        // 6 - витягнути всі пости всіх юзерів(таяк витягнути всіх працівників усіх компаній) і тоді вже робити вибірку

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Uri Avatar { get; set; }

        public List<Post> Posts { get; set; }

        public List<TodoModel> TodoModels { get; set; }
    }
}
