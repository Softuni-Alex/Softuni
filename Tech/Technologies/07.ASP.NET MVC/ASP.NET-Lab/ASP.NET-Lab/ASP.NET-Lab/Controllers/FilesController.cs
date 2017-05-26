using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NET_Lab.Controllers
{
    public class FilesController : Controller
    {
        public ActionResult ListFiles(string path = @"C:\")
        {
            var files = Directory.GetDirectories(path).ToList();
            files.AddRange(Directory.GetFiles(path));

            ViewBag.Path = path;
            ViewBag.Parent = Directory.GetParent(path);
            return View(files);
        }
    }
}