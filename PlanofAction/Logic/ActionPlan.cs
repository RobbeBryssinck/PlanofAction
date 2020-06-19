using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;
using DataHandlerInterfaces;
using DataHandlerFactory;

namespace Logic
{
    public class ActionPlan : IActionPlan
    {
        private IActionPlanContext db;
        public int ActionPlanID { get; set; }
        public int AccountID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
        public DateTime PlanDateCreated { get; set; }

        public ActionPlan(IActionPlanContext actionPlanContext)
        {
            db = actionPlanContext;
        }

        public void EditActionPlan()
        {
            db.EditActionPlan(PlanTitle, PlanMessage, PlanCategory, ActionPlanID);
        }

        public void DeleteActionPlan()
        {
            db.DeleteActionPlan(ActionPlanID);
        }
    }
}
