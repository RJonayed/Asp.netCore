using DotNetCore_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5
{
    public interface ISchoolRepository
    {
        IEnumerable<School> GetAllSchools();
        School GetSchoolsById(int id);
        School SaveSchools(School obj);
        School UpdateSchools(School upObj);
        School DeleteSchools(int id);
        IEnumerable<SlDetails> GetAllSel();
    }
}
