using DotNetCore_5.Data;
using DotNetCore_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5
{
    public class ApplicationSqlRepository : IApplicationRepository
    {

        private readonly ApplicationDbContext _context;
        public ApplicationSqlRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<School> GetAllSchools()
        {
            throw new NotImplementedException();
        }
        public School DeleteSchools(int id)
        {
            throw new NotImplementedException();
        }

        

        public School GetSchoolsById(int id)
        {
            throw new NotImplementedException();
        }

        public School SaveSchools(School obj)
        {
            throw new NotImplementedException();
        }

        public School UpdateSchools(School upObj)
        {
            throw new NotImplementedException();
        }
    }
}
