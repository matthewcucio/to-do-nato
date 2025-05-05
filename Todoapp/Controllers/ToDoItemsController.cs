using Microsoft.AspNetCore.Mvc;
using Todoapp.Models;

namespace Todoapp.Controllers
{
    public class ToDoItemsController : Controller
    {
        private static List<ToDoItemModel> _toDoItems = new List<ToDoItemModel>
        {
            new ToDoItemModel { Id = 1, Title = "Sample Task 1", IsCompleted = false },
            new ToDoItemModel { Id = 2, Title = "Sample Task 2", IsCompleted = true }
        };

        // GET: ToDoItems
        public IActionResult Index()
        {
            return View(_toDoItems);
        }

        // GET: ToDoItems/Details/1
        public IActionResult Details(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItemModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _toDoItems.Max(t => t.Id) + 1;
                _toDoItems.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ToDoItems/Edit/1
        public IActionResult Edit(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ToDoItems/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ToDoItemModel model)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                item.Title = model.Title;
                item.Description = model.Description;
                item.IsCompleted = model.IsCompleted;
                item.DueDate = model.DueDate;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ToDoItems/Delete/1
        public IActionResult Delete(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ToDoItems/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _toDoItems.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _toDoItems.Remove(item);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}