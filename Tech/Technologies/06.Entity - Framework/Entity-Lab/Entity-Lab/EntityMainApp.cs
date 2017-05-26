using System;
using System.Linq;

namespace Entity_Lab
{
    public class EntityMainApp
    {
        public static void Main(string[] args)
        {
            //QueryData();
            // CreateNewData();
            //CascadingInsert();
            //UpdateExistingData();
            //DeleteExistingData();
            NativeSQL();
        }

        private static void QueryData()
        {
            var db = new BlogDbContext();
            var query = db.Posts.Select(p => new
            {
                p.Id,
                p.Title,
                Comments = p.Comments.Count,
                Tags = p.Tags.Count
            });

            Console.WriteLine("SQL query:\n{0}\n", query);

            foreach (var post in query)
            {
                Console.WriteLine($"{post.Id} {post.Title} ({post.Comments} comments, {post.Tags} tags)");
            }
        }

        private static void CreateNewData()
        {
            var db = new BlogDbContext();
            var post = new Post()
            {
                Title = "New Title",
                Body = "New Post Body",
                Date = DateTime.Now
            };

            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine("Post #{0} created.", post.Id);
        }

        private static void CascadingInsert()
        {
            var db = new BlogDbContext();
            var post = new Post()
            {
                Title = "New Post Title",
                Date = DateTime.Now,
                Body = "This post have comments and tags",
                User = db.Users.First(),
                Comments = new Comment[] {
    new Comment() { Text = "Comment 1", Date = DateTime.Now },
    new Comment() { Text = "Comment 2", Date = DateTime.Now,
      User = db.Users.First() } },
                Tags = db.Tags.Take(3).ToList()
            };
            db.Posts.Add(post);
            db.SaveChanges();

        }

        private static void UpdateExistingData()
        {
            var db = new BlogDbContext();
            var user = db.Users.Where(u => u.UserName == "Stamat").First();

            user.PasswordHash = Guid.NewGuid().ToByteArray();
            db.SaveChanges();

            Console.WriteLine("User #{0} ({1}) has a new random password", user.Id, user.UserName);
        }

        private static void DeleteExistingData()
        {
            var db = new BlogDbContext();
            var lastPost = db.Posts.OrderByDescending(p => p.Id).First();

            db.Comments.RemoveRange(lastPost.Comments);
            lastPost.Tags.Clear();
            db.Posts.Remove(lastPost);
            db.SaveChanges();

            Console.WriteLine($"Deleted post #{lastPost.Id}");
        }

        private static void NativeSQL()
        {
            var db = new BlogDbContext();

            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);

            var posts = db.Database.SqlQuery<PostData>
                (@"SELECT Id,Title,Date FROM Posts WHERE CONVERT(date,Date)
BETWEEN {0} AND {1} ORDER BY Date", startDate, endDate);

            foreach (var postData in posts)
            {
                Console.WriteLine("#{0}: {1} ({2})",postData.Id, postData.Title,postData.Date);
            }
        }
    }

    class PostData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}