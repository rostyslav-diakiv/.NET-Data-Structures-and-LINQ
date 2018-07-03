using System;
using System.Collections.Generic;

namespace Linq.Services
{
    using System.Linq;

    using Linq.Entities;
    using Linq.Models;

    public class QueryService
    {
        private readonly IEnumerable<User> _users;
        public QueryService() { }

        public QueryService(IEnumerable<User> dataSource)
        {
            _users = new List<User>(dataSource);
        }

        #region Query #1 +
        public (IEnumerable<(Post post, int commentsAmount)> posts, int userId) GetUserPostsCommentsNumber(int userId)
        {
            var postWithNumberOfItsCommetns = _users.FirstOrDefault(u => u.Id == userId)
                                                    ?.Posts.Select(p => (p, p.Comments.Count));
            return (postWithNumberOfItsCommetns, userId);
        }

        public void ShowUserPostsCommentsNumber(IEnumerable<(Post post, int commentsAmount)> posts, int userId)
        {
            Console.WriteLine("Query #1");
            Console.WriteLine($"Number of comments under User's posts for user with id: {userId}");
            if (posts == null) return;

            foreach (var p in posts)
            {
                Console.WriteLine($"{p}, comments amount: {p.commentsAmount}");
            }
        }
        #endregion

        #region Query #2 +
        public (IEnumerable<CommentModel> comments, int userId) GetUserPostsComments(int userId)
        {
            var comments = _users.FirstOrDefault(u => u.Id == userId)
                                 ?.Posts.SelectMany(p => p.Comments.Where(c => c.Body.Length < 50));

            return (comments, userId);
        }

        public void ShowUserPostsComments(IEnumerable<CommentModel> comments, int userId)
        {
            Console.WriteLine("Query #2");
            Console.WriteLine($"Comments below User's posts for user with id: {userId}");
            foreach (var c in comments)
            {
                Console.WriteLine(c);
            }
        }
        #endregion

        #region Query #3 +
        public (IEnumerable<(int id, string name)> todos, int userId) GetUserCompletedTodos(int userId)
        {
            var doneTodosForUserById = _users.FirstOrDefault(u => u.Id == userId)
                                             ?.TodoModels.Where(t => t.IsComplete)
                                                         .Select(t => (Id: t.Id, Name: t.Name));
            return (doneTodosForUserById, userId);
        }

        public void ShowUserCompletedTodos(IEnumerable<(int id, string name)> completedTodos, int userId)
        {
            Console.WriteLine("Query #3");
            Console.WriteLine($"Completed Todos for user with id: {userId}");
            foreach (var t in completedTodos)
            {
                Console.WriteLine($"Todo id:{t.id}, name: {t.name}");
            }
        }
        #endregion

        #region Query #4 + 
        public IEnumerable<User> Query4()
        {
            var sortedUsers = _users.OrderBy(u => u.Name)
                                    .Select(u => new User(u, u.TodoModels.OrderByDescending(t => t.Name.Length)));
            return sortedUsers;
        }

        public static void ShowQuery4(IEnumerable<User> users, int skip = 0, int take = 15)
        {
            Console.WriteLine("Query #4");
            Console.WriteLine("Users sorted by Name ascending with Todos sorted by Name Lenght by descending:");
            foreach (var u in users.Skip(skip).Take(take))
            {
                Console.WriteLine($"User id: {u.Id}, name: {u.Name}, Todos: ");
                foreach (var t in u.TodoModels)
                {
                    Console.WriteLine($"Todo id:{t.Id}, name: {t.Name}");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Query #5 +
        public (User user, Post lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, Post popPost, Post popPostLikes) Query5(int userId)
        {
            var tuple = (from u in _users
                         where u.Id == userId
                         select (u, // User 
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Comments.Count,
                                 u.TodoModels.Count(t => !t.IsComplete),
                                 u.Posts.OrderByDescending(p => p.Comments.Count(c => c.Body.Length > 80)).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.Likes).FirstOrDefault())).First();

            return tuple;
        }

        public void ShowQuery5((User user, Post lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, Post popPost, Post popPostLikes) complexTuple)
        {
            Console.WriteLine("Query #5");
            Console.WriteLine(complexTuple.user);
            Console.WriteLine($"Last user's post: {complexTuple.lastPost}");
            Console.WriteLine($"Number of Comments under last user's post: {complexTuple.lastPostCommentsAmount}");
            Console.WriteLine($"Amount of UnCompleted Todos: {complexTuple.uncompletedTasksAmount}");
            const string text = "The most popular user's post (based on amount of";
            Console.WriteLine($"{text} comments that have body lenght more that 80 chars): {complexTuple.popPost}");
            Console.WriteLine($"{text} likes: {complexTuple.popPostLikes}");
        }
        #endregion

        #region Query #6 +
        public (Post post, CommentModel longestComment, CommentModel mostPopComment, int commentsAmount) Query6(int postId)
        {
            var postData = _users.SelectMany(u => u.Posts.Where(p => p.Id == postId)).Select(po => (po,
                                                                                                       po.Comments.OrderByDescending(c => c.Body.Length).FirstOrDefault(),
                                                                                                       po.Comments.OrderByDescending(c => c.Likes).FirstOrDefault(),
                                                                                                       po.Comments.Count(cm => cm.Likes == 0 || cm.Body.Length < 80))).FirstOrDefault();

            return postData;
        }

        public void ShowQuery6((Post post, CommentModel longestComment, CommentModel mostPopComment, int commentsAmount) complexTuple)
        {
            Console.WriteLine("Query #6");
            Console.WriteLine(complexTuple.post);
            Console.WriteLine($"The longest post's comment: {complexTuple.longestComment}");
            Console.WriteLine($"The most liked post's comment: {complexTuple.mostPopComment}");
            Console.WriteLine($"Number of post's comments with 0 likes or with body length less than 80 chars: {complexTuple.commentsAmount}");
        }
        #endregion
    }
}
