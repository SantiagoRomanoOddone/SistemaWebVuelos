﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Filters
{
    public class MyFilterAction : ActionFilterAttribute
    {
        // TIENE QUE SER PUBLIC
        //Filtro de acción - ANTES
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //controller/action
            //{controller}/{action}
            //Vuelo/Create
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + " Action:" + action + " Paso por OnActionExecuting");
        }

        //Filtro de acción - después
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + " Action:" + action + " Paso por OnActionExecuted");
        }
    }
}