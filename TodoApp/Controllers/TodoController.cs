using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Contexts;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (Bp215efContext context = new())
            {

                return View(await context.Todos.ToListAsync());
            }

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Todo data)
        {
            using (Bp215efContext context = new())
            {
                await context.Todos.AddAsync(data);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            using (Bp215efContext context = new Bp215efContext())
            {
                if (await context.Todos.AnyAsync(x => x.Id == id))
                {
                    context.Todos.Remove(new Todo
                    {
                        Id = id.Value

                    });
                    await context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            using (Bp215efContext context = new())
            {
                var data = await context.Todos.FindAsync(id.Value);
                if(data is null) return BadRequest();   

            return View(data );

            }
        }
        [HttpPost]
        public async Task<IActionResult> Update( int? id, Todo data)
        {
            if (!id.HasValue) return BadRequest();
            using (Bp215efContext context = new())
            {
                var entity = await context.Todos.FindAsync(id);
                if (data is null) return NotFound();
                entity.Title = data.Title;
                entity.Description = data.Description;
                entity.Deadline = data.Deadline;
                await context.SaveChangesAsync ();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
