using DotNetCore_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Intefaces
{
   public interface IApplicationRepo
    {
        IEnumerable<ApplicationFrom> GetAllApplication();
        ApplicationFrom GetAppById(int id);
        ApplicationFrom SaveApp(ApplicationFrom obj);
        ApplicationFrom UpdateApp(ApplicationFrom upObj);
        ApplicationFrom DeleteApp(int id);

        //IEnumerable<Training> GetAllTrainings();
        //Training GetTrainingById(int id);
        //Training SaveTraining(Training obj);
    }
}
