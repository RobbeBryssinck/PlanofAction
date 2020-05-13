using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IActionPlanCollection
    {
        int CreateActionPlan(IActionPlan actionPlan);
        List<IActionPlan> GetActionPlans();
    }
}