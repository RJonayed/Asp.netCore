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
    public class SecBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SecBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SecBoards
        public async Task<IActionResult> Index()
        {
            return View(await _context.SecBoards.ToListAsync());
        }

        // GET: SecBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secBoard = await _context.SecBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secBoard == null)
            {
                return NotFound();
            }

            return View(secBoard);
        }

        // GET: SecBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SecBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position,SlNO,ApplicantId")] SecBoard secBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secBoard);
        }

        // GET: SecBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secBoard = await _context.SecBoards.FindAsync(id);
            if (secBoard == null)
            {
                return NotFound();
            }
            return View(secBoard);
        }

        // POST: SecBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position,SlNO,ApplicantId")] SecBoard secBoard)
        {
            if (id != secBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecBoardExists(secBoard.Id))
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
            return View(secBoard);
        }

        // GET: SecBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secBoard = await _context.SecBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secBoard == null)
            {
                return NotFound();
            }

            return View(secBoard);
        }

        // POST: SecBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secBoard = await _context.SecBoards.FindAsync(id);
            _context.SecBoards.Remove(secBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecBoardExists(int id)
        {
            return _context.SecBoards.Any(e => e.Id == id);
        }
    }
}
