﻿using System;
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
            PoAContext context = HttpContext.RequestServices.GetService(typeof(PoAContext)) as PoAContext;

            int rowsAffected = context.CreateActionPlan(actionPlan);

            return RedirectToAction("CreationSuccessful");
        }
    }
}