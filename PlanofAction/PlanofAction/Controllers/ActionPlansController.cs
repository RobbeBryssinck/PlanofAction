using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;

namespace PlanofAction.Controllers
{
    public class ActionPlansController : Controller
    {
        public IActionResult Index()
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlans());
        }

        public IActionResult PlanPage(int actionPlanID)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlan(actionPlanID));
        }
    }
}