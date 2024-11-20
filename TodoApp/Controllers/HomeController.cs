using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Hi(string name, int age)
        {
            List<string> Names = ["Cavidan", "talib", "yusif", "Resad", "Nerman"];
            ViewData["Qerdesler"] = Names;
            return View("Bdu");
        }
        //public ContentResult Hello(string name, int age)
        //{
        //    ContentResult content = new ContentResult();
        //    content.Content = "<h1> SAlamlar<h1>";
        //    content.ContentType = "text/html";
        //    return content;

        //}
    }
}
