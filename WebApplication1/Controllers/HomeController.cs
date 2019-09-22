using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Service;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IUserService UserSvc { get; set; }
        public HomeController(IUserService UserSvc)
        {
            this.UserSvc = UserSvc;
        }
        public async Task<IActionResult> GetAll()
        {
            string username = HttpContext.User.Identity.Name;
            return Json(await UserSvc.GetNoramlAll());
        }
    }
}
