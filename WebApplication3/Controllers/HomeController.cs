using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Service;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IUserService UserSvc { get; set; }
        public HomeController(IUserService UserSvc)
        {
            this.UserSvc = UserSvc;
        }
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            string username = this.User.FindFirst("Name").Value;
            return new JsonResult(await UserSvc.GetNoramlAll());
        }
    }
}