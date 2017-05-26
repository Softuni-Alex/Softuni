using MVCBlog.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var posts = this.db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(5).ToList();

            this.ViewBag.SideBarPosts = posts;
            return this.View(posts.ToList());
        }
    }
}