namespace Linq.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Linq.Entities;
    using Linq.Interfaces;
    using Linq.Models;

    using Newtonsoft.Json;

    public class DataManager : IDataManager
    {
        public async Task<IEnumerable<User>> PrepareDataForQuerying()
        {
            var data = await FetchDataFromApi().ConfigureAwait(false);
            var users = CombineData(data);
            return users;
        }

        private async Task<(List<UserModel> userModels, List<PostModel> postModels, List<CommentModel> commentModels, List<TodoModel> todoModels)> FetchDataFromApi()
        {
            // Fetch and Join data
            using (var handler = new HttpClientHandler())
            using (var client =
                new HttpClient(handler) { BaseAddress = new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/") })
            {
                var usersTask = client.GetAsync("users");
                var postsTask = client.GetAsync("posts");
                var commentsTask = client.GetAsync("comments");
                var todosTask = client.GetAsync("todos");

                var requestsTasks = new[] { usersTask, postsTask, commentsTask, todosTask };

                await Task.WhenAll(requestsTasks).ConfigureAwait(false);

                var readUsersTask = usersTask.Result.Content.ReadAsStringAsync();
                var readPostsTask = postsTask.Result.Content.ReadAsStringAsync();
                var readCommentsTask = commentsTask.Result.Content.ReadAsStringAsync();
                var readTodosTask = todosTask.Result.Content.ReadAsStringAsync();

                var readTasks = new[] { readUsersTask, readPostsTask, readCommentsTask, readTodosTask };

                await Task.WhenAll(readTasks).ConfigureAwait(false);

                var userModels = JsonConvert.DeserializeObject<List<UserModel>>(readUsersTask.Result);
                var postModels = JsonConvert.DeserializeObject<List<PostModel>>(readPostsTask.Result);
                var commentModels = JsonConvert.DeserializeObject<List<CommentModel>>(readCommentsTask.Result);
                var todoModels = JsonConvert.DeserializeObject<List<TodoModel>>(readTodosTask.Result);

                return (userModels, postModels, commentModels, todoModels);
            }
        }

        private IEnumerable<User> CombineData((List<UserModel> userModels, List<PostModel> postModels, List<CommentModel> commentModels, List<TodoModel> todoModels) dataToCombine)
        {
            var users = from um in dataToCombine.userModels
                        join p in (from pm in dataToCombine.postModels
                                join cm in dataToCombine.commentModels on pm.Id equals cm.PostId into cms
                                select new Post(pm, cms)) on um.Id equals p.UserId into ps
                     join tm in dataToCombine.todoModels on um.Id equals tm.UserId into tms
                     // orderby um.Name
                     select new User(um, tms, ps);

            return users;
        }
    }
}
