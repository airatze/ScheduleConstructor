using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleConstructor.Data;
using ScheduleConstructor.Models;

namespace ScheduleConstructor.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ScheduleContext _context;

        public LessonsController(ScheduleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var scheduleContext = _context.Lessons.Include(l => l.Teacher);
            return View(await scheduleContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Name,TeacherID")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "ID", "Name", lesson.TeacherID);
            return View(lesson);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "ID", "Name", lesson.TeacherID);
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,TeacherID")] Lesson lesson)
        {
            if (id != lesson.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.ID))
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
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "ID", "Name", lesson.TeacherID);
            return View(lesson);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.ID == id);
        }
    }
}
