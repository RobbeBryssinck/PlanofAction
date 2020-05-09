using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;
using PlanofAction.Data;
using PlanofAction.ViewModels;
using Logic.Models;

namespace PlanofAction.Controllers
{
    public class ActionPlansController : Controller
    {
        private ActionPlan actionPlan;
        public ActionPlansController()
        {
            this.actionPlan = new ActionPlan();
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
        public IActionResult Create(CreateActionPlanViewModel actionPlan)
        {
            int rowsAffected = db.CreateActionPlan(actionPlan.AccountID, actionPlan.PlanTitle,
                                                    actionPlan.PlanMessage, actionPlan.PlanCategory);

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
            ActionPlanDto actionPlan = db.GetActionPlan(actionPlanID);

            db.DeleteActionPlan(actionPlan);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int actionPlanID)
        {
            return View(db.GetActionPlan(actionPlanID));
        }

        [HttpPost]
        public IActionResult EditPost(ActionPlanDto actionPlan)
        {
            db.EditActionPlan(actionPlan);

            return RedirectToAction("Index");
        }
    }
}