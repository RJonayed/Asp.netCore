using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCore_5.Data;
using DotNetCore_5.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DotNetCore_5.Controllers
{
    public class ApplicationFromsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationFromsController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.applicationFroms.Include(a => a.School).Include(a => a.Branch).Include(a => a.Class);
            return View(await applicationDbContext.ToListAsync());
        }
        public ActionResult TotCount()
        {
            string count = "";
            count= "Total Aplication:" + _context.applicationFroms.Count().ToString();
            return PartialView(count); ;
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationFrom = await _context.applicationFroms
                .Include(a => a.Branch)
                .Include(a => a.Class)
                .Include(a => a.School)
                .FirstOrDefaultAsync(m => m.SlNO == id);
            if (applicationFrom == null)
            {
                return NotFound();
            }

            return View(applicationFrom);
        }

        public IActionResult Create()
        {
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "SchoolName");
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName");
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlNO,ApplicantId,ApplicantName,Gender,Religion,BirthRegistrationNo,ImageUrl,FatherName,MothrsName,ContNo,Address,ApplicationDate,IsSelect,ClassId,BranchId,SchoolId")] ApplicationFrom applicationFrom,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    string picture = System.IO.Path.GetFileName(file.FileName);
                    //path = ProcessUploadFile();
                    //file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        applicationFrom.ImageUrl = ms.GetBuffer().ToString();
                    }
                }
                _context.Add(applicationFrom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "Address", applicationFrom.SchoolId);
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchLocation", applicationFrom.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", applicationFrom.ClassId);

            return View(applicationFrom);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationFrom = await _context.applicationFroms.FindAsync(id);
            if (applicationFrom == null)
            {
                return NotFound();
            }
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "SchoolName", applicationFrom.SchoolId);
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", applicationFrom.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", applicationFrom.ClassId);
            return View(applicationFrom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlNO,ApplicantId,ApplicantName,Gender,Religion,BirthRegistrationNo,ImageUrl,FatherName,MothrsName,ContNo,Address,ApplicationDate,IsSelect,ClassId,BranchId,SchoolId")] ApplicationFrom applicationFrom, IFormFile file)
        {
            if (id != applicationFrom.SlNO)
            {
                return NotFound();
            }
            string path = "";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    //string picture = System.IO.Path.GetFileName(file.FileName);
                    path = ProcessUploadFile();
                    //file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        applicationFrom.ImageUrl = ms.GetBuffer().ToString();
                    }
                }
                try
                {
                    _context.Update(applicationFrom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationFromExists(applicationFrom.SlNO))
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
            ViewData["SchoolId"] = new SelectList(_context.schools, "SchoolId", "SchoolName", applicationFrom.SchoolId);
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", applicationFrom.BranchId);
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", applicationFrom.ClassId);
            return View(applicationFrom);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationFrom = await _context.applicationFroms
                .Include(a => a.Branch)
                .Include(a => a.Class)
                .Include(a => a.School)
                .FirstOrDefaultAsync(m => m.SlNO == id);
            if (applicationFrom == null)
            {
                return NotFound();
            }

            return View(applicationFrom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationFrom = await _context.applicationFroms.FindAsync(id);
            _context.applicationFroms.Remove(applicationFrom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationFromExists(int id)
        {
            return _context.applicationFroms.Any(e => e.SlNO == id);
        }
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploadFile = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            uniqueFileName = fileName;
                        }
                    }

                }
            }

            return uniqueFileName;
        }
    }
}
