using DotNetCore_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Intefaces
{
    public interface IAdmissionRepo
    {
       public IEnumerable<ApplicationFrom> GetAllApplicaton();
       public ApplicationFrom GetApplicationById(int id);
       public ApplicationFrom SaveApplication(ApplicationFrom obj);
       public ApplicationFrom UpdateApplication(ApplicationFrom upObj);
       public  ApplicationFrom DeleteApplication(int id);
    }
}
