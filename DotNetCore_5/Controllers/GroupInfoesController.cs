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
    public class GroupInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.groupInfos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.groupInfos
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (groupInfo == null)
            {
                return NotFound();
            }

            return View(groupInfo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupName,IsActive")] GroupInfo groupInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupInfo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.groupInfos.FindAsync(id);
            if (groupInfo == null)
            {
                return NotFound();
            }
            return View(groupInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,GroupName,IsActive")] GroupInfo groupInfo)
        {
            if (id != groupInfo.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupInfoExists(groupInfo.GroupId))
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
            return View(groupInfo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.groupInfos
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (groupInfo == null)
            {
                return NotFound();
            }

            return View(groupInfo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupInfo = await _context.groupInfos.FindAsync(id);
            _context.groupInfos.Remove(groupInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupInfoExists(int id)
        {
            return _context.groupInfos.Any(e => e.GroupId == id);
        }
    }
}
