namespace Linq.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Uri Avatar { get; set; }
    }
}
