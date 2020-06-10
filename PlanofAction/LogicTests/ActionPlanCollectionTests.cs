using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Autofac.Extras.Moq;
using DataHandlerInterfaces;
using DataHandler.Models;

namespace Logic.Tests
{
    [TestClass()]
    public class ActionPlanCollectionTests
    {
        [TestMethod()]
        public void InstantiateActionPlans_4ActionPlans_AreEqual()
        {
            var mock = new Mock<IActionPlanContext>();
            mock.Setup(x => x.GetActionPlans()).Returns(GetActionPlans(false));

            var actionPlanCollection = new ActionPlanCollection(mock.Object);
            var actualValue = actionPlanCollection.InstantiateActionPlans();

            Assert.AreEqual(actualValue.Count, 4);
        }
        
        [TestMethod()]
        public void InstantiateActionPlans_0ActionPlans_AreEqual()
        {
            var mock = new Mock<IActionPlanContext>();
            mock.Setup(x => x.GetActionPlans()).Returns(GetActionPlans(true));

            var actionPlanCollection = new ActionPlanCollection(mock.Object);
            var actualValue = actionPlanCollection.InstantiateActionPlans();

            Assert.AreEqual(actualValue.Count, 0);
        }

        [TestMethod()]
        public void GetActionPlan_IDIs2_AreEqual()
        {
            var mock = new Mock<IActionPlanContext>();
            mock.Setup(x => x.GetActionPlans()).Returns(GetActionPlans(false));

            var actionPlanCollection = new ActionPlanCollection(mock.Object);
            var actualValue = actionPlanCollection.GetActionPlan(2);

            Assert.AreEqual(actualValue.ActionPlanID, 2);
        }

        [TestMethod()]
        public void GetActionPlan_IDIs5_IsNull()
        {
            var mock = new Mock<IActionPlanContext>();
            mock.Setup(x => x.GetActionPlans()).Returns(GetActionPlans(false));

            var actionPlanCollection = new ActionPlanCollection(mock.Object);
            var actualValue = actionPlanCollection.GetActionPlan(5);

            Assert.IsNull(actualValue);
        }

        private List<IActionPlanDto> GetActionPlans(bool isEmpty)
        {
            if (isEmpty)
                return new List<IActionPlanDto>();

            List<IActionPlanDto> actionPlans = new List<IActionPlanDto>
            {
                new ActionPlanDto
                {
                    ActionPlanID = 1,
                    AccountID = 2,
                    PlanTitle = "Climate change topic 1",
                    PlanMessage = "Climate change message 1",
                    PlanDateCreated = DateTime.Now,
                    PlanCategory = "Category 1"
                },

                new ActionPlanDto
                {
                    ActionPlanID = 2,
                    AccountID = 1,
                    PlanTitle = "Climate change topic 2",
                    PlanMessage = "Climate change message 2",
                    PlanDateCreated = DateTime.Now,
                    PlanCategory = "Category 2"
                },

                new ActionPlanDto
                {
                    ActionPlanID = 3,
                    AccountID = 1,
                    PlanTitle = "Climate change topic 3",
                    PlanMessage = "Climate change message 3",
                    PlanDateCreated = DateTime.Now,
                    PlanCategory = "Category 1"
                },

                new ActionPlanDto
                {
                    ActionPlanID = 4,
                    AccountID = 3,
                    PlanTitle = "Climate change topic 4",
                    PlanMessage = "Climate change message 4",
                    PlanDateCreated = DateTime.Now,
                    PlanCategory = "Category 6"
                }
            };

            return actionPlans;
        }
    }
}