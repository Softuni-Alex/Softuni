﻿namespace HotelBookingSystem.Core
{
    using Infrastructure;
    using Interfaces;
    using Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Utilities;
    using Views.Shared;

    public class Engine : IEngine
    {
        private readonly IHotelBookingSystemData database;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(IHotelBookingSystemData database, IInputReader reader, IOutputWriter writer)
        {
            this.database = database;
            this.reader = reader;
            this.writer = writer;
        }

        public void StartOperation()
        {
            User currentUser = null;
            while (true)
            {
                string url = this.reader.ReadLine();
                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
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

                this.writer.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var methodParams = action.GetParameters();
            var result = new object[methodParams.Length];
            int pos = 0;

            foreach (var param in methodParams)
            {
                object value = null;
                if (param.ParameterType == typeof(DateTime))
                {
                    value = DateTime.ParseExact(executionEndpoint.Parameters[param.Name], Constants.DateFormat,
                        CultureInfo.InvariantCulture);
                }
                else
                {
                    value = Convert.ChangeType(executionEndpoint.Parameters[param.Name],
                       param.ParameterType);
                }

                result[pos++] = value;
            }
            return result;
        }
    }
}