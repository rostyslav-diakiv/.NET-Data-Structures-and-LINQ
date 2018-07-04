namespace Linq
{
    using System;
    using System.Threading.Tasks;

    using Linq.Services;

    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            var menu = new Menu();
            await menu.SetUp().ConfigureAwait(false);
            menu.Start(true);

            Console.ReadKey();
        }
    }
}
