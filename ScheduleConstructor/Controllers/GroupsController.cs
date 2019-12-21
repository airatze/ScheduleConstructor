using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleConstructor.Models;
using ScheduleConstructor.Models.Page;

namespace ScheduleConstructor.Data
{
    public class GroupsController : Controller
    {
        private readonly ScheduleContext _context;

        public GroupsController(ScheduleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            var groups = from g in _context.Groups select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                groups = groups.Where(g => g.Name.Contains(searchString));
            }


            int pageSize = 3;
            //return View(await _context.AsNoTracking().ToListAsync());
            return View(await PaginatedList<Group>.CreateAsync(groups.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(s => s.Subjects)
                .ThenInclude(s => s.Audience)
                .Include(s => s.Subjects)
                .ThenInclude(s => s.Lesson)
                .ThenInclude(s => s.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Group @group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(@group);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Ошибка при добавлении имени, пожалуйста, проверьте данные");
            }

            return View(@group);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Group @group)
        {
            if (id != @group.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.ID))
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
            return View(@group);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "возникла ошибка при попытке удаления";
            }

            return View(@group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Groups.Remove(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.ID == id);
        }
    }
}
