using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;

namespace Logic.Models
{
    public class ActionPlanCollection : IActionPlanCollection
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
            return ActionPlans;
        }
    }
}
