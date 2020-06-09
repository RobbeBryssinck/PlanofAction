using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanofAction.Models;
using PlanofAction.ViewModels;
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
            actionPlan = LogicFactory.LogicFactory.GetActionPlan();
            actionPlanCollection = LogicFactory.LogicFactory.GetActionPlanCollection();
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
            actionPlan = actionPlanCollection.GetActionPlan(actionPlanID);

            PlanPageViewModel model = new PlanPageViewModel()
            {
                PlanTitle = actionPlan.PlanTitle,
                PlanMessage = actionPlan.PlanMessage
            };

            return View(model);
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
            actionPlan = actionPlanCollection.GetActionPlan(actionPlanID);

            DeletePlanViewModel model = new DeletePlanViewModel()
            {
                ActionPlanID = actionPlan.ActionPlanID,
                AccountID = actionPlan.AccountID,
                PlanTitle = actionPlan.PlanTitle,
                PlanMessage = actionPlan.PlanMessage,
                PlanCategory = actionPlan.PlanCategory,
                PlanDateCreated = actionPlan.PlanDateCreated
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePost(int actionPlanID)
        {
            actionPlan = actionPlanCollection.GetActionPlan(actionPlanID);

            actionPlan.DeleteActionPlan();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int actionPlanID)
        {
            actionPlan = actionPlanCollection.GetActionPlan(actionPlanID);

            EditPlanViewModel model = new EditPlanViewModel()
            {
                ActionPlanID = actionPlan.ActionPlanID,
                PlanTitle = actionPlan.PlanTitle,
                PlanMessage = actionPlan.PlanMessage,
                PlanCategory = actionPlan.PlanCategory
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPost(EditPlanViewModel model)
        {
            actionPlan.ActionPlanID = model.ActionPlanID;
            actionPlan.PlanTitle = model.PlanTitle;
            actionPlan.PlanMessage = model.PlanMessage;
            actionPlan.PlanCategory = model.PlanCategory;

            actionPlan.EditActionPlan();

            return RedirectToAction("Index");
        }
    }
}