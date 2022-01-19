using DotNetCore_5.Data;
using DotNetCore_5.Intefaces;
using DotNetCore_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Repository
{
    public class AdmissionRepo : IAdmissionRepo
    {
        private readonly ApplicationDbContext _context;
        public AdmissionRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public ApplicationFrom DeleteApplication(int id)
        {
            ApplicationFrom applicationFrom = GetApplicationById(id);
            if (applicationFrom != null)
            {
                _context.applicationFroms.Remove(applicationFrom);
                _context.SaveChanges();
            }
            return applicationFrom;
        }

        public IEnumerable<ApplicationFrom> GetAllApplicaton()
        {
            return _context.applicationFroms;
        }

        public ApplicationFrom GetApplicationById(int id)
        {
            ApplicationFrom applicationFrom = _context.applicationFroms.Find(id);
            return applicationFrom;
        }

        public ApplicationFrom SaveApplication(ApplicationFrom obj)
        {
            _context.applicationFroms.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public ApplicationFrom UpdateApplication(ApplicationFrom upObj)
        {
            var app = _context.applicationFroms.Attach(upObj);
            app.State =EntityState.Modified;
            _context.SaveChanges();
            return upObj;
        }
    }
}
