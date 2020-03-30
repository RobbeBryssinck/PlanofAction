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
        private PoAContext db;
        public ActionPlansController(PoAContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.GetActionPlans());
        }

        [HttpGet]
        public IActionResult PlanPage(int actionPlanID)
        {
            return View(db.GetActionPlan(actionPlanID));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ActionPlan actionPlan)
        {
            int rowsAffected = db.CreateActionPlan(actionPlan);

            if (rowsAffected == 1)
                return RedirectToAction("CreationSuccessful");
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
            return View(db.GetActionPlan(actionPlanID));
        }

        [HttpPost]
        public IActionResult DeletePost(int actionPlanID)
        {
            ActionPlan actionPlan = db.GetActionPlan(actionPlanID);

            db.DeleteActionPlan(actionPlan);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int actionPlanID)
        {
            return View(db.GetActionPlan(actionPlanID));
        }

        [HttpPost]
        public IActionResult EditPost(ActionPlan actionPlan)
        {
            db.EditActionPlan(actionPlan);

            return RedirectToAction("Index");
        }
    }
}