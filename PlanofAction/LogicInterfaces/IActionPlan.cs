using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LogicInterfaces
{
    public interface IActionPlan
    {
        public int ActionPlanID { get; set; }
        public int AccountID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
        public DateTime PlanDateCreated { get; set; }

        public void EditActionPlan();
        public void DeleteActionPlan();
    }
}
