using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Votedress.BusinessLayer;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.WebApp.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

      
    }
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
    
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);

            VotedressUser SessionControl = context.HttpContext.Session["login"] as VotedressUser;
            if (SessionControl == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Giris" }, { "url", context.HttpContext.Request.RawUrl } });

            }

        }
    }

    public class BireyselUserFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);

            VotedressUser SessionControl = context.HttpContext.Session["login"] as VotedressUser;
            if (SessionControl.Role == "kurumsal")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Admin" }, { "action", "Index" }, { "url", context.HttpContext.Request.RawUrl } });

            }

        }
    }
    public class KurumsalUserFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }


        //action metot çalıştırıldığı an devreye giriyor
        public void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);

            VotedressUser SessionControl = context.HttpContext.Session["login"] as VotedressUser;
            if (SessionControl.Role == "bireysel")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Oylama" }, { "action", "Index" }, { "url", context.HttpContext.Request.RawUrl } });

            }

        }
    }

    public class LoglamaFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            VotedressUser SessionControl = filterContext.HttpContext.Session["login"] as VotedressUser;
            if (SessionControl!=null)
            {
                var contollerAdi = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionAdi = filterContext.ActionDescriptor.ActionName;
                var tarih = filterContext.HttpContext.Timestamp;
                string id="";
                if (contollerAdi=="Gardrop" && actionAdi=="Magaza")
                {
                    id = filterContext.HttpContext.Request.QueryString["id"];
                }

                Logla(SessionControl, contollerAdi, actionAdi,id ,tarih);
            }

            base.OnActionExecuting(filterContext);
        }

        public void Logla(VotedressUser Session,string controllerAdi,string actionAdi,string parameter,DateTime tarih)
        {
            ControllerLoglamaManager controllerLoglamaManager = new ControllerLoglamaManager();
            controllerLoglamaManager.Logla(Session,controllerAdi,actionAdi, parameter,tarih);

        }
    }


}