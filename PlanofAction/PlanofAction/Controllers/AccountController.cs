using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicFactory;
using LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.ViewModels;

namespace PlanofAction.Controllers
{
    public class AccountController : Controller
    {
        private IAccount account;

        public AccountController()
        {
            account = Factory.GetAccount();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            bool loginAttempt = account.LoginQuery(model.Username, model.Password);

            if (loginAttempt)
                return Content("Login succeeded!");

            else
                return Content("Login Failed");
        }
    }
}