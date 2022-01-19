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
    public class SchoolsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApplicationSqlRepository _applicationSqlRepository;
        public SchoolsController(ApplicationDbContext context)
        {
            this._context = context;
            //this._applicationSqlRepository = applicationSqlRepository;
        }

        public async Task<IActionResult> Index(string sortOrder,string currentFilter, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
           
            ViewData["CurrentFilter"] = searchString;
            var students = from s in _context.schools
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.SchoolName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EstDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.SchoolName);
                    break;
                default:
                    students = students.OrderBy(s => s.SchoolName);
                    break;
            }

            return View(await students.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolId,SchoolName,Email,Address,EstDate")] School school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolId,SchoolName,Email,Address,EstDate")] School school)
        {
            if (id != school.SchoolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.SchoolId))
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
            return View(school);
        }
        //[HttpPost]
        //public PartialViewResult EditClient(int SchoolId)
        //{
        //    School scl = new School();
        //    ViewBag.School = scl;
        //    if (SchoolId > 0)
        //    {
        //        var user = _context.schools.SingleOrDefault(x => x.SchoolId == SchoolId);
        //        scl.SchoolName = user.SchoolName;
        //        scl.Email = user.Email;
        //        scl.EstDate = user.EstDate;
        //    }
        //    ViewBag.Details = "Show";
        //    return PartialView("_EditRecord", scl);

        //}

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = await _context.schools.FindAsync(id);
            _context.schools.Remove(school);
            await _context.SaveChangesAsync();
            //return View(school);
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(int id)
        {
            return _context.schools.Any(e => e.SchoolId == id);
        }
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }

            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);

                this.AddRange(items);
            }

            public bool HasPreviousPage
            {
                get
                {
                    return (PageIndex > 1);
                }
            }

            public bool HasNextPage
            {
                get
                {
                    return (PageIndex < TotalPages);
                }
            }

            public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
            {
                var count = await source.CountAsync();
                var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
        }
    }
}