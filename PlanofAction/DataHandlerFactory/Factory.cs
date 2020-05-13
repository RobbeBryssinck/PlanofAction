using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandlerFactory
{
    public static class Factory
    {
        public static IActionPlanContext GetActionPlanContext()
        {
            return new ActionPlanContext();
        }

        public static IActionPlanDto GetActionPlanDto()
        {
            return new ActionPlanDto();
        }
    }
}

