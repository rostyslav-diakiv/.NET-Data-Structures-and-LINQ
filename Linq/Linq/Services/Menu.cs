using System;

namespace Linq.Services
{
    using System.Threading.Tasks;

    using Linq.Interfaces;

    public class Menu : IMenu
    {
        private IQueryService _queryService;

        private readonly string separator = new string('-', 140);

        public Menu() { }

        public async Task SetUp()
        {
            var dataManager = new DataManager();
            var users = await dataManager.PrepareDataForQuerying().ConfigureAwait(false);

            _queryService = new QueryService(users);
        }

        public void Start(bool showMenu)
        {
            if (showMenu)
            {
                ShowMenu();
            }

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nEnter User id: ");
                    var idString = Console.ReadLine();
                    bool intParseResult = int.TryParse(idString, out int id);
                    if (intParseResult)
                    {
                        // 1
                        var postsWithUserId = _queryService.GetUserPostsCommentsNumber(id); // 24
                        _queryService.ShowUserPostsCommentsNumber(postsWithUserId.posts, postsWithUserId.userId);
                        
                        Console.WriteLine(separator);
                    }
                    else Console.WriteLine("Wrong User Id");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("\nEnter User id: ");
                    var idString2 = Console.ReadLine();
                    bool intParseResult2 = int.TryParse(idString2, out int id2);
                    if (intParseResult2)
                    {
                        // 2
                        var comments = _queryService.GetUserPostsComments(id2); // 24
                        _queryService.ShowUserPostsComments(comments.comments, comments.userId);

                        Console.WriteLine(separator);
                    }
                    else Console.WriteLine("Wrong User Id");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("\nEnter User id: ");
                    var idString3 = Console.ReadLine();
                    bool intParseResult3 = int.TryParse(idString3, out int id3);
                    if (intParseResult3)
                    {
                        // 3
                        var todosWithUserId = _queryService.GetUserCompletedTodos(id3);
                        _queryService.ShowUserCompletedTodos(todosWithUserId.todos, todosWithUserId.userId);

                        Console.WriteLine(separator);
                    }
                    else Console.WriteLine("Wrong User Id");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("\nEnter number of users you wanna get: ");
                    var amountString = Console.ReadLine();
                    bool intParseResult4 = int.TryParse(amountString, out int amount);
                    if (intParseResult4)
                    {
                        // 4
                        var sortedUsers = _queryService.Query4();
                        _queryService.ShowQuery4(sortedUsers, 0, amount);

                        Console.WriteLine(separator);
                    }
                    else Console.WriteLine("Wrong amount");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("\nEnter User id: ");
                    var idString5 = Console.ReadLine();
                    bool intParseResult5 = int.TryParse(idString5, out int id5);
                    if (intParseResult5)
                    {
                        // 5
                        var complexTuple = _queryService.Query5(id5); // 24
                        _queryService.ShowQuery5(complexTuple);

                        Console.WriteLine(separator);
                    }
                    else Console.WriteLine("Wrong User Id");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("\nEnter Post id: ");
                    var idString6 = Console.ReadLine();
                    bool intParseResult6 = int.TryParse(idString6, out int id6);
                    if (intParseResult6)
                    {
                        // 6
                        var complexTuple2 = _queryService.Query6(id6);
                        _queryService.ShowQuery6(complexTuple2);
                    }
                    else Console.WriteLine("Wrong Post Id");

                    ShowStandartMessage();
                    break;
                case ConsoleKey.R:
                    Start(true);
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    ShowStandartMessage();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong key!");
                    ShowStandartMessage();
                    break;
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nTo execute 1st Query press: 1"
                              + "\nTo execute 2nd Query press: 2"
                              + "\nTo execute 3rd Query press: 3"
                              + "\nTo execute 4th Query press: 4"
                              + "\nTo execute 5th Query press: 5"
                              + "\nTo execute 6th Query press: 6"
                              + "\nTo clear the console Press: C"
                              + "\nTo Exit from program Press: Esc");
        }

        private void ShowStandartMessage()
        {
            Console.WriteLine("\nPress Esc to exit or \"R\" to show menu or try previous commands again");
            Start(false);
        }
    }
}
