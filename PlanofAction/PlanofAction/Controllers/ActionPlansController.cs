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
        [HttpGet]
        public IActionResult Index()
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlans());
        }

        [HttpGet]
        public IActionResult PlanPage(int actionPlanID)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlan(actionPlanID));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ActionPlan actionPlan)
        {
            if (ModelState.IsValid)
            {
                PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

                int rowsAffected = context.CreateActionPlan(actionPlan);

                if (rowsAffected == 1)
                    return RedirectToAction("CreationSuccessful");
                else
                    return RedirectToAction("CreationFailed");
            }
            else
                return RedirectToAction("CreationFailed");
        }

        [HttpGet]
        public IActionResult CreationSuccessful()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreationFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int actionPlanID)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlan(actionPlanID));
        }

        [HttpPost]
        public IActionResult DeletePost(int actionPlanID)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            ActionPlan actionPlan = context.GetActionPlan(actionPlanID);

            int rowsAffected = context.DeleteActionPlan(actionPlan);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int actionPlanID)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            return View(context.GetActionPlan(actionPlanID));
        }

        [HttpPost]
        public IActionResult EditPost(ActionPlan actionPlan)
        {
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            int rowsAffected = context.EditActionPlan(actionPlan);

            return RedirectToAction("Index");
        }
    }
}