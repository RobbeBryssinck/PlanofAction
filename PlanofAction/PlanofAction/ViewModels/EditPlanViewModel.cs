using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class EditPlanViewModel
    {
        public int ActionPlanID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
    }
}
