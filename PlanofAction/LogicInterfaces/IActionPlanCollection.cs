using System.Collections.Generic;

namespace LogicInterfaces
{
    public interface IActionPlanCollection
    {
        List<IActionPlan> GetActionPlans();
        IActionPlan GetActionPlan(int actionPlanID);
        int CreateActionPlan(IActionPlan actionPlan);
        List<IActionPlan> InstantiateActionPlans();
    }
}