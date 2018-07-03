namespace Linq
{
    using System;
    using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            string separator = new string('-', 140);


            // 1
            var todosWithUserId = GetUserCompletedTodos(200);
            ShowUserCompletedTodos(todosWithUserId.todos, todosWithUserId.userId);

            Console.WriteLine(separator);

            // 2
            var comments = GetUserPostsComments(24);
            ShowUserPostsComments(comments.comments, comments.userId);

            Console.WriteLine(separator);

            // 3
            var postsWithUserId = GetUserPostsCommentsNumber(24);
            ShowUserPostsCommentsNumber(postsWithUserId.posts, postsWithUserId.userId);

            Console.WriteLine(separator);

            // 4
            var sortedUsers = Query4();
            ShowQuery4(sortedUsers, 0, 20);

            Console.WriteLine(separator);

            // 5
            var complexTuple = Query5(24);
            ShowQuery5(complexTuple);

            Console.WriteLine(separator);

            // 6
            var complexTuple2 = Query6(3);
            ShowQuery6(complexTuple2);

            Console.ReadKey();
        }
    }
}
