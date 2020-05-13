using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;
using PlanofAction.Data;
using PlanofAction.ViewModels;
using Logic.Models;
using LogicFactory;
using LogicInterfaces;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PlanofAction.Controllers
{
    public class ActionPlansController : Controller
    {
        private IActionPlan actionPlan;
        private IActionPlanCollection actionPlanCollection;

        public ActionPlansController()
        {
            actionPlan = Factory.GetActionPlan();
            actionPlanCollection = Factory.GetActionPlanCollection();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<IActionPlan> actionPlans = actionPlanCollection.GetActionPlans();
            ActionPlanIndexViewModel model = new ActionPlanIndexViewModel();

            model.ActionPlans = actionPlans;

            return View(model);
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
        public IActionResult Create(CreateActionPlanViewModel model)
        {
            actionPlan.AccountID = model.AccountID;
            actionPlan.PlanTitle = model.PlanTitle;
            actionPlan.PlanMessage = model.PlanMessage;
            actionPlan.PlanCategory = model.PlanCategory;

            int rowcount = actionPlanCollection.CreateActionPlan(actionPlan);

            if (rowcount == 1)
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
        public IActionResult EditPost(string title, string message, string category)
        {
            IActionPlan actionPlan = ActionPlanFactory.GetActionPlan();

            return RedirectToAction("Index");
        }
    }
}