using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Autofac.Extras.Moq;
using DataHandlerFactory;
using DataHandlerInterfaces;
using LogicInterfaces;
using DataHandler.Models;

namespace Logic.Tests
{
    [TestClass()]
    public class ActionPlanCollectionTests
    {
        [TestMethod()]
        public void InstantiateActionPlansTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IActionPlanContext>()
                    .Setup(x => x.GetActionPlans())
                    .Returns(GetActionPlans());

                var cls = mock.Create<ActionPlanCollection>();
                var expected = GetActionPlans();
                var actual = cls.InstantiateActionPlans();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [TestMethod()]
        public void ActionPlanCollectionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateActionPlanTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetActionPlansTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetActionPlanTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IActionPlanContext>()
                    .Setup(x => x.GetActionPlans())
                    .Returns(GetActionPlans());

                var cls = mock.Create<ActionPlanCollection>();
            }
        }

        private List<IActionPlanDto> GetActionPlans()
        {
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