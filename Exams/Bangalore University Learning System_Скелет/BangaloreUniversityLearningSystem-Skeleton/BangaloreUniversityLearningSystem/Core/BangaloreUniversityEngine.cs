namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    public class BangaloreUniversityEngine : IEngine
    {
        public void Run()
        {
            var db = new BangaloreUniversityData();
            User user = null;
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                var route = new Route(input);
                var controllerType =
                    Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, db, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] parameters = this.MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        protected virtual object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(route.Parameters[p.Name]);
                    }

                    return route.Parameters[p.Name];
                }).ToArray();
        }
    }
}