using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Exercises
{
    public class BlogMainApp
    {
        static void Main()
        {
            //ListAllPosts();
            //ListAllUsers();
            //ListTitleBodyFromPosts();
            //OrderData();
            //OrderByTwoColumns();
            //SelectAuthors();
            //JoinAuthorsWithTitles();
            //SelectAuthorOfSpecificPost();
            //OrderPostsAuthors();
            //CreateData();
            //UpdateData();
            DeleteData();
        }

        private static void DeleteData()
        {
            BlogDbContext database = new BlogDbContext();

            Post postInfo = database.Posts.Single(post => post.Id == 31);

            database.Comments.RemoveRange(postInfo.Comments);

            postInfo.Tags.Clear();

            database.Posts.Remove(postInfo);

            database.SaveChanges();

            Console.WriteLine(@"Post #{0} deleted succesfully", postInfo.Id);
        }

        private static void UpdateData()
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            User userInfo = blogDbContext.Users.Single(user => user.UserName == "GBotev");

            string oldName = userInfo.FullName;

            userInfo.FullName = "Georgi Botev";

            blogDbContext.SaveChanges();

            Console.WriteLine(@"User '{0}' has been renamed to '{1}'", oldName, userInfo.FullName);
        }

        private static void CreateData()
        {
            BlogDbContext database = new BlogDbContext();

            Post post = new Post()
            {
                AuthorId = 2,
                Title = "Random Title",
                Body = "Random Content"
            };

            database.Posts.Add(post);
            database.SaveChanges();

            Console.WriteLine("Post #{0} Created!", post.Id);
        }

        private static void OrderPostsAuthors()
        {
            BlogDbContext database = new BlogDbContext();

            var users = database.Users.Where(user => user.Posts.Count > 0)
                .OrderByDescending(user => user.Id);

            foreach (var user in users)
            {
                Console.WriteLine("UserName: " + user.UserName);
                Console.WriteLine("FullName: " + user.FullName);
            }
        }

        private static void SelectAuthorOfSpecificPost()
        {
            BlogDbContext database = new BlogDbContext();

            var author = database.Users.SelectMany(user => user.Posts, (user, post) => new
            {
                user.UserName,
                user.FullName,
                post.Id
            }).Single(post => post.Id == 4);

            Console.WriteLine("Username: {0}", author.UserName);
            Console.WriteLine("Full name: {0}", author.FullName);
            Console.WriteLine();
        }

        private static void JoinAuthorsWithTitles()
        {
            BlogDbContext database = new BlogDbContext();

            var users = database.Users.SelectMany(user => user.Posts, (user, post) => new
            {
                user.UserName,
                post.Title
            });
        }

        private static void SelectAuthors()
        {
            BlogDbContext database = new BlogDbContext();
            List<User> users = database.Users.Where(user => user.Posts.Count > 0).ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
                Console.WriteLine("Posts Count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void OrderByTwoColumns()
        {
            BlogDbContext database = new BlogDbContext();

            var users = database.Users.Select(user => new
            {
                user.UserName,
                user.FullName
            })
                .OrderByDescending(user => user.UserName)
                .ThenByDescending(user => user.FullName)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full Name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void OrderData()
        {
            BlogDbContext database = new BlogDbContext();

            var users = database.Users.Select(user => new
            {
                user.UserName,
                user.FullName
            })
            .OrderBy(user => user.UserName).ToList();

            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void ListTitleBodyFromPosts()
        {
            BlogDbContext database = new BlogDbContext();

            var posts = database.Posts.Select(post => new
            {
                post.Title,
                post.Body
            }).ToList();

            foreach (var post in posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("Content: {0}", post.Body);
                Console.WriteLine();
            }
        }

        private static void ListAllUsers()
        {
            BlogDbContext database = new BlogDbContext();

            List<User> users = database.Users.Select(user => user).ToList();

            foreach (var user in users)
            {
                Console.WriteLine("ID: {0}", user.Id);
                Console.WriteLine("Name: {0}", user.FullName);
                Console.WriteLine("Comments Count: {0}", user.Comments.Count);
                Console.WriteLine("Posts Count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void ListAllPosts()
        {
            BlogDbContext database = new BlogDbContext();
            List<Post> posts = database.Posts.Select(post => post).ToList();

            foreach (Post post in posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("AuthorId: {0}", post.AuthorId);
                Console.WriteLine("Comments Count: {0}", post.Comments.Count);
                Console.WriteLine("Tags Count: {0}", post.Tags.Count);
                Console.WriteLine();
            }
        }

    }
}