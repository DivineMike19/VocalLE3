using BlogDataLibrary.Data;
using BlogDataLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogTestUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Setup Dependency Injection
            var services = new ServiceCollection();
            services.AddSingleton(config);
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            services.AddSingleton<SqlData>();

            var serviceProvider = services.BuildServiceProvider();
            var data = serviceProvider.GetService<SqlData>();


            UserModel? loggedInUser = null;

            while (true)
            {
                Console.WriteLine("\n=== Blog Menu ===");
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Login");
                Console.WriteLine("3 - Add Post");
                Console.WriteLine("4 - List Posts");
                Console.WriteLine("5 - View Post Details");
                Console.WriteLine("0 - Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Register
                        Console.Write("Enter username: ");
                        string regUser = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string regPass = Console.ReadLine();
                        Console.Write("Enter first name: ");
                        string fname = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lname = Console.ReadLine();

                        await data.Register(regUser, regPass, fname, lname);
                        Console.WriteLine(" User registered.");
                        break;

                    case "2": // Login
                        Console.Write("Enter username: ");
                        string loginUser = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string loginPass = Console.ReadLine();

                        loggedInUser = await data.Authenticate(loginUser, loginPass);
                        Console.WriteLine(loggedInUser != null ? " Login successful!" : " Login failed.");
                        break;

                    case "3": // Add Post
                        if (loggedInUser == null)
                        {
                            Console.WriteLine(" Please login first.");
                            break;
                        }
                        Console.Write("Enter post title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter post body: ");
                        string body = Console.ReadLine();

                        await data.AddPost(loggedInUser.Id, title, body);
                        Console.WriteLine(" Post added.");
                        break;

                    case "4": // List Posts
                        var posts = await data.ListPosts();
                        foreach (var post in posts)
                            Console.WriteLine($"{post.Id}: {post.Title} by {post.Username} on {post.DateCreated}");
                        break;

                    case "5": // Post Details
                        Console.Write("Enter Post ID: ");
                        if (int.TryParse(Console.ReadLine(), out int postId))
                        {
                            var postDetails = await data.ShowPostDetails(postId);
                            if (postDetails != null)
                            {
                                Console.WriteLine($"Title: {postDetails.Title}");
                                Console.WriteLine($"Author: {postDetails.Username}");
                                Console.WriteLine($"Date: {postDetails.DateCreated}");
                                Console.WriteLine($"Body: {postDetails.Body}");
                            }
                            else
                            {
                                Console.WriteLine(" Post not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Invalid Post ID.");
                        }
                        break;

                    case "0": // Exit
                        Console.WriteLine(" Exiting Blog App...");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
