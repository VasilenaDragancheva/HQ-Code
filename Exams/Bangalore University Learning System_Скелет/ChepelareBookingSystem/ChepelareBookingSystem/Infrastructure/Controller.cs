﻿namespace ChepelareBookingSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using ChepelareBookingSystem.Identity;
    using ChepelareBookingSystem.Interfaces;
    using ChepelareBookingSystem.Models;
    using ChepelareBookingSystem.Utilities;

    using HotelBookingSystem.Views.Shared;

    public class Controller
    {
        internal Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public User CurrentUser { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IHotelBookingSystemData Data { get; private set; }

        protected void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(
                    "The currently logged in user doesn't have sufficient rights to perform this operation.", 
                    this.CurrentUser);
            }
        }

        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamespaceSeparator, 
                baseNamespace, 
                Constants.ViewsFolder, 
                controllerName, 
                actionName);
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }
    }
}