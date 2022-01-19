using DotNetCore_5.Data;
using DotNetCore_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5
{
    public class ScholllRepository : ISchoolRepository
    {

        private readonly ApplicationDbContext _context;
        public ScholllRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<School> GetAllSchools()
        {
            return _context.schools;
        }
        public School DeleteSchools(int id)
        {
            School school = GetSchoolsById(id);
            if (school != null)
            {
                _context.schools.Remove(school);
                _context.SaveChanges();
            }
            return school;
        }

        public School GetSchoolsById(int id)
        {
            School school = _context.schools.Find(id);
            return school;
        }

        public School SaveSchools(School obj)
        {
            _context.schools.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public School UpdateSchools(School upObj)
        {
            var stu = _context.schools.Attach(upObj);
            stu.State = EntityState.Modified;
            _context.SaveChanges();
            return upObj;
        }

        public IEnumerable<SlDetails> GetAllSel()
        {
            return _context.SlDetails;
        }
    }
}
