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
    public class SlDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SlDetails.Include(s => s.Branch).Include(s => s.Class).Include(s => s.School);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slDetails = await _context.SlDetails
                .Include(s => s.Branch)
                .Include(s => s.Class)
                .Include(s => s.School)
                .FirstOrDefaultAsync(m => m.SlDetailsID == id);
            if (slDetails == null)
            {
                return NotFound();
            }

            return View(slDetails);
        }

        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName");
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName");
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "SchoolName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlDetailsID,SlNO,ClassId,Id,SchoolId,BranchId")] SlDetails slDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchLocation", slDetails.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", slDetails.ClassId);
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "Address", slDetails.SchoolId);
            return View(slDetails);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slDetails = await _context.SlDetails.FindAsync(id);
            if (slDetails == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchLocation", slDetails.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", slDetails.ClassId);
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "Address", slDetails.SchoolId);
            return View(slDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlDetailsID,SlNO,ClassId,Id,SchoolId,BranchId")] SlDetails slDetails)
        {
            if (id != slDetails.SlDetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlDetailsExists(slDetails.SlDetailsID))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchLocation", slDetails.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", slDetails.ClassId);
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "Address", slDetails.SchoolId);
            return View(slDetails);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slDetails = await _context.SlDetails
                .Include(s => s.Branch)
                .Include(s => s.Class)
                .Include(s => s.School)
                .FirstOrDefaultAsync(m => m.SlDetailsID == id);
            if (slDetails == null)
            {
                return NotFound();
            }

            return View(slDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slDetails = await _context.SlDetails.FindAsync(id);
            _context.SlDetails.Remove(slDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlDetailsExists(int id)
        {
            return _context.SlDetails.Any(e => e.SlDetailsID == id);
        }
    }
}
