namespace ChepelareBookingSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using ChepelareBookingSystem.Infrastructure;
    using ChepelareBookingSystem.Interfaces;
    using ChepelareBookingSystem.Models;
    using ChepelareBookingSystem.Utilities;

    using HotelBookingSystem.Infrastructure;
    using HotelBookingSystem.Views.Shared;

    public class Engine : IEngine
    {
        private readonly IHotelBookingSystemData database;

        public Engine(IHotelBookingSystemData database)
        {
            this.database = database;
        }

        public void StartOperation()
        {
            User currentUser = null;
            string url;
            while (true)
            {
                url = Console.ReadLine();
                if (string.IsNullOrEmpty(url))
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var controller = Activator.CreateInstance(controllerType, this.database, currentUser) as Controller;

                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                Console.WriteLine(viewResult);
            }
        }

        private object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action.GetParameters().Select<ParameterInfo, object>(
                p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(
                            executionEndpoint.Parameters[p.Name],
                            Constants.DateFormat,
                            CultureInfo.InvariantCulture);
                    }

                    return executionEndpoint.Parameters[p.Name];
                }).ToArray();

            return parameters;
        }
    }
}