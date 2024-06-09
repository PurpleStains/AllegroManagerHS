using AllegroConnector.Application.AllegroApi.Commands;
using AllegroConnector.Domain.Orders;
using AllegroConnector.Infrastructure;
using NetArchTest.Rules;
using NUnit.Framework;
using System.Reflection;

namespace AllegroManager.Modules.Allegro.AllegroConnector.ArchTests.SeedWork
{
    public abstract class TestBase
    {
        protected static Assembly ApplicationAssembly => typeof(SeedOrdersCommand).Assembly;

        protected static Assembly DomainAssembly => typeof(Order).Assembly;

        protected static Assembly InfrastructureAssembly => typeof(AllegroContext).Assembly;

        protected static void AssertAreImmutable(IEnumerable<Type> types)
        {
            List<Type> failingTypes = [];
            foreach (var type in types)
            {
                if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
                {
                    failingTypes.Add(type);
                    break;
                }
            }

            AssertFailingTypes(failingTypes);
        }

        protected static void AssertFailingTypes(IEnumerable<Type> types)
        {
            Assert.That(types, Is.Null.Or.Empty);
        }

        protected static void AssertArchTestResult(TestResult result)
        {
            AssertFailingTypes(result.FailingTypes);
        }
    }
}
