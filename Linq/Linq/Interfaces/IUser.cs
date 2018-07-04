namespace Linq.Interfaces
{
    using System.Collections.Generic;

    using Linq.Entities;
    using Linq.Models;

    public interface IUser : IUserModel
    {
        List<Post> Posts { get; set; }

        List<TodoModel> TodoModels { get; set; }
    }
}