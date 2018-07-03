using System;

namespace Linq
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Linq.Entities;
    using Linq.Models;

    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            // Join on id
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler) { BaseAddress = new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/") })
            {
                var usersTask = client.GetAsync("users");
                var postsTask = client.GetAsync("posts");
                var commentsTask = client.GetAsync("comments");
                var todosTask = client.GetAsync("todos");
                
                var requestsTasks = new Task<HttpResponseMessage>[]
                                        {
                                            usersTask,
                                            postsTask,
                                            commentsTask,
                                            todosTask
                                        };

                await Task.WhenAll(requestsTasks).ConfigureAwait(false);


                var readUsersTask = usersTask.Result.Content.ReadAsStringAsync();
                var readPostsTask = postsTask.Result.Content.ReadAsStringAsync();
                var readCommentsTask = commentsTask.Result.Content.ReadAsStringAsync();
                var readTodosTask = todosTask.Result.Content.ReadAsStringAsync();

                var readTasks = new Task<string>[]
                                    {
                                        readUsersTask,
                                        readPostsTask,
                                        readCommentsTask,
                                        readTodosTask
                                    };

                await Task.WhenAll(readTasks).ConfigureAwait(false);
                
                var userModels = JsonConvert.DeserializeObject<List<UserModel>>(readUsersTask.Result);
                var postModels = JsonConvert.DeserializeObject<List<PostModel>>(readPostsTask.Result);
                var commentModels = JsonConvert.DeserializeObject<List<CommentModel>>(readCommentsTask.Result);
                var todoModels = JsonConvert.DeserializeObject<List<TodoModel>>(readTodosTask.Result);

                var users = (from um in userModels
                            join tm in todoModels on um.Id equals tm.UserId into tms
                            select new User(um, tms)).ToList();

                // 3. Получить список(id, name) из списка todos которые выполнены для конкретного пользователя(по айди)
                var doneTodosForUserById = users.FirstOrDefault(u => u.Id == 8)?.TodoModels.Where(t => t.IsComplete).Select(t => new { Id = t.Id, Name = t.Name });

                #region tests

                //var query = from um in userModels
                //            let u = new User()
                //            join tm in todoModels on um.Id equals tm.UserId into tms
                //            from subpet in tms
                //            select new Todo(new User(um, tms), subpet);

                //var query1 = from um in userModels
                //            let u = new User()
                //            join tm in todoModels on um.Id equals tm.UserId into tms
                //            select u.Initialize(um, from t in tms select new Todo(u, tm));

                //var query = userModels    // your starting point - table in the "from" statement
                //    .Join(todoModels,    // the source table of the inner join
                //        u => u.Id,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                //        t => t.UserId,   // Select the foreign key (the second part of the "on" clause)
                //        (u, t) => new User() {Todos = new List<Todo>(){ new Todo(){ User = this} }}) // selection


                #endregion

                Console.ReadKey();
            }
        }


    }
}
