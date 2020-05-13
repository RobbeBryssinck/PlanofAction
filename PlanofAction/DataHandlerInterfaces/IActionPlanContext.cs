using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IActionPlanContext
    {
        string ConnectionString { get; set; }

        void CreateActionPlan(IActionPlanDto actionPlanDto);
        void DeleteActionPlan(int actionPlanID);
        void EditActionPlan(string planTitle, string planMessage, string planCategory, int actionPlanID);
        IActionPlanDto GetActionPlan(int actionPlanID);
        List<IActionPlanDto> GetActionPlans();
    }
}