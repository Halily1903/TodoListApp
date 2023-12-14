using Microsoft.AspNetCore.Mvc;
using TodoListApp.Entities;
using TodoListApp.Models.EntityFramework;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Todos.OrderByDescending(x=>x.Id).ToList();
            return View(result);
        }
        [HttpPost]
        public IActionResult Index(string title)
        {
            Todo todo = new Todo();
            todo.Title = title;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Where(x=>x.Id==id).FirstOrDefault();
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
