using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;

namespace Logic.Models
{
    public class ActionPlan : IActionPlan
    {
        public int ActionPlanID { get; set; }
        public int AccountID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
        public DateTime PlanDateCreated { get; set; }

        public void CreateActionPlan(int accountID, string planTitle, string planMessage, string planCategory)
        {
            return;
        }

        public void EditActionPlan(string title, string message, string category, int actionPlanID)
        {
            db.EditActionPlan(title, message, category);
        }

        public void DeleteActionPlan(int actionPlanID)
        {
            throw new NotImplementedException();
        }
    }
}
