using DotNetCore_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetMyFriends()
        {
            List<Friend> friends = new List<Friend>();
            friends.Add(new Friend { Name = "Jonayed", Address = "Dhaka", Mobile = "0168542154", Id = 101 });
            friends.Add(new Friend { Name = "Habib", Address = "Dhaka", Mobile = "0168542154", Id = 102 });
            friends.Add(new Friend { Name = "Shakil", Address = "Dhaka", Mobile = "0168542154", Id = 103 });
            friends.Add(new Friend { Name = "Jabir", Address = "Dhaka", Mobile = "0168542154", Id = 104 });
            return Json(friends);
        }
    }
}
