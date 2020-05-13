﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;

namespace Logic.Models
{
    class ActionPlanCollection
    {
        private ActionPlanContext db;
        private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi406843;Database=dbi406843;Pwd=kwf40C1@s&OM;";

        private List<ActionPlan> ActionPlans { get; set; }

        public ActionPlanCollection()
        {
            db = new ActionPlanContext(connectionString);
            List<ActionPlanDto> actionPlanDtos = db.GetActionPlans();
            foreach (ActionPlanDto actionPlanDto in actionPlanDtos)
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

        public List<ActionPlan> GetActionPlans()
        {
            return ActionPlans;
        }
    }
}
