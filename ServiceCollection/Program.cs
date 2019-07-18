using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceCollectionDemo
{
    class Program
    {

        static void Main(string[] args)
        {

            var services = new ServiceCollection()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<ICommentService, CommentService>()
                .BuildServiceProvider();

            var u = services.GetService<IUserService>();

            Console.WriteLine("Hello World!");
        }
    }
}
