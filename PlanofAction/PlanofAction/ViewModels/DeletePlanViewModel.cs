﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanofAction.ViewModels
{
    public class DeletePlanViewModel
    {
        public int ActionPlanID { get; set; }
        public int AccountID { get; set; }
        public string PlanTitle { get; set; }
        public string PlanMessage { get; set; }
        public string PlanCategory { get; set; }
        public DateTime PlanDateCreated { get; set; }
    }
}
