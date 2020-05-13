using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;
using DataHandlerInterfaces;
using DataHandlerFactory;

namespace Logic.Models
{
    class ActionPlanCollection
    {
        private IActionPlanContext db;

        private List<ActionPlan> ActionPlans { get; set; }

        public ActionPlanCollection()
        {
            db = Factory.GetActionPlanContext();
            List<IActionPlanDto> actionPlanDtos = db.GetActionPlans();
            foreach (IActionPlanDto actionPlanDto in actionPlanDtos)
            {
                ActionPlans.Add(new ActionPlan()
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

        public void CreateActionPlan(ActionPlan actionPlan)
        {
            IActionPlanDto actionPlanDto = Factory.GetActionPlanDto();
            actionPlanDto.AccountID = actionPlan.AccountID;
            actionPlanDto.ActionPlanID = actionPlan.ActionPlanID;
            actionPlanDto.PlanTitle = actionPlan.PlanTitle;
            actionPlanDto.PlanMessage = actionPlan.PlanMessage;
            actionPlanDto.PlanCategory = actionPlan.PlanCategory;
            actionPlanDto.PlanDateCreated = actionPlan.PlanDateCreated;

            db.CreateActionPlan(actionPlanDto);
        }

        public List<ActionPlan> GetActionPlans()
        {
            return ActionPlans;
        }
    }
}
