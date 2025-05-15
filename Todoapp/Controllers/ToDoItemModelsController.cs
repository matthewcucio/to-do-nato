using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todoapp.Data;
using Todoapp.Models;
using Microsoft.Extensions.Logging;

namespace Todoapp.Controllers
{
    public class ToDoItemModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ToDoItemModelsController> _logger;

        public ToDoItemModelsController(ApplicationDbContext context, ILogger<ToDoItemModelsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // --- ADD THIS DTO CLASS FOR AJAX STATUS UPDATE ---
        public class StatusUpdateDto
        {
            public string Status { get; set; }
        }

        // --- ADD THIS ENDPOINT FOR AJAX STATUS UPDATE ---
        [HttpPost]
        [IgnoreAntiforgeryToken] // For AJAX, or handle the token properly
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateDto dto)
        {
            var item = await _context.ToDoItemModels.FindAsync(id);
            if (item == null) return NotFound();

            if (!Enum.TryParse<Status>(dto.Status, out var newStatus))
                return BadRequest("Invalid status value.");

            item.Status = newStatus;
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        // --- ADD THIS ENDPOINT FOR CLEAR ALL ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearAll()
        {
            _context.ToDoItemModels.RemoveRange(_context.ToDoItemModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Status,Deadline,Description")] ToDoItemModel toDoItemModel)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Status,Deadline,Description")] ToDoItemModel toDoItemModel)
        {
            if (id != toDoItemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Updated Deadline: {Deadline}", toDoItemModel.Deadline);
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