using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Context;
using DataHandlerInterfaces;

namespace DataHandlerFactory
{
    public static class Factory
    {
        public static IActionPlanContext GetActionPlanContext(string connectionString)
        {
            return new ActionPlanContext(connectionString);
        }
    }
}

