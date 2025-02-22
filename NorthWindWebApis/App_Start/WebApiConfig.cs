﻿using NorthWindWebApis.App_Start;
using System;
using System.Web.Http;

namespace NorthWindWebApis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            StructuremapWebApi.Start();
            AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Projects\\NorthWindWebApis\\NorthWindWebApis.DataLayer\\App_Data\\");
            
        }
    }
}