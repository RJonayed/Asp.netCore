 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCore_5.Data;
using DotNetCore_5.Models;

namespace DotNetCore_5.Controllers
{
    public class SelectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SlNO = new SelectList(_context.applicationFroms, "SlNO", "ApplicantName");
            return View(await _context.selections.ToListAsync());

            //var applicationDbContext = _context.applicationFroms.Include(b => b.SlNO);
            //return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.selections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selection == null)
            {
                return NotFound();
            }

            return View(selection);
        }
        public IActionResult Create()
        {
            ViewData["SlNO"] = new SelectList(_context.applicationFroms, "SlNO", "ApplicantName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position,SlNO")] Selection selection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SlNO"] = new SelectList(_context.applicationFroms, "SlNO", "ApplicantName");
            return View(selection);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.selections.FindAsync(id);
            if (selection == null)
            {
                return NotFound();
            }
            ViewData["SlNO"] = new SelectList(_context.applicationFroms, "SlNO", "ApplicantName");
            return View(selection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position,SlNO")] Selection selection)
        {
            if (id != selection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelectionExists(selection.Id))
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
            ViewData["SlNO"] = new SelectList(_context.applicationFroms, "SlNO", "ApplicantName");
            return View(selection);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.selections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selection == null)
            {
                return NotFound();
            }

            return View(selection);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selection = await _context.selections.FindAsync(id);
            _context.selections.Remove(selection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelectionExists(int id)
        {
            return _context.selections.Any(e => e.Id == id);
        }
    }
}
