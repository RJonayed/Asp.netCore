using DotNetCore_5.Data;
using DotNetCore_5.Intefaces;
using DotNetCore_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Repository
{    
    public class ApplicationSqlRepo: IApplicationRepo
    {
        private readonly ApplicationDbContext _contex;
        public ApplicationSqlRepo(ApplicationDbContext context)
        {
            this._contex = context;
        }

        public ApplicationFrom DeleteApp(int id)
        {
            ApplicationFrom applicationFrom = GetAppById(id);
            if (applicationFrom!= null)
            {
                _contex.applicationFroms.Remove(applicationFrom);
                _contex.SaveChanges();
            }
            return applicationFrom;
        }

        public IEnumerable<ApplicationFrom> GetAllApplication()
        {
            throw new NotImplementedException();
        }

        public ApplicationFrom GetAppById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationFrom SaveApp(ApplicationFrom obj)
        {
            throw new NotImplementedException();
        }

        public ApplicationFrom UpdateApp(ApplicationFrom upObj)
        {
            throw new NotImplementedException();
        }
    }
}
