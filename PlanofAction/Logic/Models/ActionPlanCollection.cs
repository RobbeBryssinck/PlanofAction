﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System.Linq;

namespace Logic.Models
{
    public class ActionPlanCollection : IActionPlanCollection
    {
        private IActionPlanContext db;
        private List<IActionPlan> actionPlans;

        public ActionPlanCollection()
        {
            db = Factory.GetActionPlanContext();
            actionPlans = new List<IActionPlan>();
            List<IActionPlanDto> actionPlanDtos = db.GetActionPlans();
            foreach (IActionPlanDto actionPlanDto in actionPlanDtos)
            {
                actionPlans.Add(new ActionPlan()
                {
                    ActionPlanID = actionPlanDto.ActionPlanID,
                    AccountID = actionPlanDto.AccountID,
                    PlanTitle = actionPlanDto.PlanTitle,
                    PlanMessage = actionPlanDto.PlanMessage,
                    PlanCategory = actionPlanDto.PlanCategory,
                    PlanDateCreated = actionPlanDto.PlanDateCreated
                });
            }
        }

        public int CreateActionPlan(IActionPlan actionPlan)
        {
            IActionPlanDto actionPlanDto = Factory.GetActionPlanDto();
            actionPlanDto.AccountID = actionPlan.AccountID;
            actionPlanDto.PlanTitle = actionPlan.PlanTitle;
            actionPlanDto.PlanMessage = actionPlan.PlanMessage;
            actionPlanDto.PlanCategory = actionPlan.PlanCategory;
            actionPlanDto.PlanDateCreated = actionPlan.PlanDateCreated;

            int rowcount = db.CreateActionPlan(actionPlanDto);
            return rowcount;
        }

        public List<IActionPlan> GetActionPlans()
        {
            return actionPlans;
        }

        public IActionPlan GetActionPlan(int actionPlanID)
        {
            return actionPlans.Where(model => model.ActionPlanID == actionPlanID).FirstOrDefault();
        }
    }
}