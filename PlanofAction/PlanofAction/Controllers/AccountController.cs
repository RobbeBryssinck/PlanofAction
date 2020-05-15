using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;
using PlanofAction.Data;

namespace PlanofAction.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account model)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            bool loginAttempt = context.LoginQuery(model.Username, model.Password);

            if (loginAttempt)
                return Content("Login succeeded!");

            else
                return Content("Login Failed");
        }
    }
}