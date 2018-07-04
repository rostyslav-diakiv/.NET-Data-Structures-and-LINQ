using System;

namespace Linq.Interfaces
{
    public interface IUserModel
    {
        Uri Avatar { get; set; }
        DateTime CreatedAt { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}