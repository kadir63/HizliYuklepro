﻿using HizliYukle.BLL.Repositories;
using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace HizliYukle.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        Repository<YukVeren> repoYukveren = new Repository<YukVeren>();
        Repository<Admin> repoAdmin = new Repository<Admin>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpCookie httpCookie = Request.Cookies["CKDil"];
            if (httpCookie != null && httpCookie.Value != "")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(httpCookie.Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(httpCookie.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
        }
            protected void Application_AuthenticateRequest(Object sender, EventArgs e)
            {
                if (HttpContext.Current.User != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        string rol = "";
                        if (HttpContext.Current.User.Identity.Name[0] == '#') rol = repoAdmin.GetBy(f => f.KullaniciAdi == HttpContext.Current.User.Identity.Name.Replace("#", "")).Rol;
                    else rol = repoYukveren.GetBy(f => f.Rol == HttpContext.Current.User.Identity.Name).Rol;
                    string[] roles = rol.Split(',');
                        HttpContext.Current.User = new GenericPrincipal((FormsIdentity)HttpContext.Current.User.Identity, roles);
                    }
                }
            }
        }
    }
