using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todoapp.Data;
using Todoapp.Models;

namespace Todoapp.Controllers
{
    public class ToDoItemModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToDoItemModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoItemModels.ToListAsync());
        }

        // GET: ToDoItemModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItemModel = await _context.ToDoItemModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return View(toDoItemModel);
        }

        // GET: ToDoItemModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItemModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IsCompleted")] ToDoItemModel toDoItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoItemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItemModel);
        }

        // GET: ToDoItemModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItemModel = await _context.ToDoItemModels.FindAsync(id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }
            return View(toDoItemModel);
        }

        // POST: ToDoItemModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IsCompleted")] ToDoItemModel toDoItemModel)
        {
            if (id != toDoItemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoItemModelExists(toDoItemModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItemModel);
        }

        // GET: ToDoItemModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItemModel = await _context.ToDoItemModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return View(toDoItemModel);
        }

        // POST: ToDoItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoItemModel = await _context.ToDoItemModels.FindAsync(id);
            if (toDoItemModel != null)
            {
                _context.ToDoItemModels.Remove(toDoItemModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoItemModelExists(int id)
        {
            return _context.ToDoItemModels.Any(e => e.Id == id);
        }
    }
}
