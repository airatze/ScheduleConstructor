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
    public class SubjectsController : Controller
    {
        private readonly ScheduleContext _context;

        public SubjectsController(ScheduleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var scheduleContext = _context.Subjects.Include(s => s.Group).Include(s => s.Lesson);
            return View(await scheduleContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Group)
                .Include(s => s.Lesson)
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "Name");
            ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "Name");
            ViewData["AudienceNumber"] = new SelectList(_context.Audiences, "Number", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("SubjectID,LessonID,GroupID,NumberInDay,NumberInWeek,AudienceNumber")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "Name", subject.GroupID);
            ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "Name", subject.LessonID);
            ViewData["AudienceNumber"] = new SelectList(_context.Audiences, "Number", "Number", subject.AudienceNumber);

            return View(subject);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "Name", subject.GroupID);
            ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "Name", subject.LessonID);
            ViewData["AudienceNumber"] = new SelectList(_context.Audiences, "Number", "Number", subject.AudienceNumber);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectID,LessonID,GroupID,NumberInDay,NumberInWeek,AudienceNumber")] Subject subject)
        {
            if (id != subject.SubjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "Name", subject.GroupID);
            ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "Name", subject.LessonID);
            ViewData["AudienceNumber"] = new SelectList(_context.Audiences, "Number", "Number", subject.AudienceNumber);
            return View(subject);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Group)
                .Include(s => s.Lesson)
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectID == id);
        }
    }
}
