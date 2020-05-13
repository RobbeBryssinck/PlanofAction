using System;

namespace DataHandlerInterfaces
{
    public interface IActionPlanDto
    {
        int AccountID { get; set; }
        int ActionPlanID { get; set; }
        string PlanCategory { get; set; }
        DateTime PlanDateCreated { get; set; }
        string PlanMessage { get; set; }
        string PlanTitle { get; set; }
    }
}