using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataHandlerInterfaces;

namespace DataHandler.Models
{
    public class ActionPlanDto : IActionPlanDto
    {
        public int ActionPlanID { get; set; }
        public int AccountID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
        public DateTime PlanDateCreated { get; set; }
    }
}
