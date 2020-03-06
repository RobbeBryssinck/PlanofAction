using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanofAction.Controllers
{
    public class ActionPlansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}