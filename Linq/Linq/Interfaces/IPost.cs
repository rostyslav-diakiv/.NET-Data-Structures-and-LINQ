namespace Linq.Interfaces
{
    using System.Collections.Generic;

    using Linq.Models;

    public interface IPost
    {
        List<CommentModel> Comments { get; set; }
    }
}