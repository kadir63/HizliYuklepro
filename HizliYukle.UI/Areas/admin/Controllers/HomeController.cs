﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizliYukle.UI.Areas.admin.Controllers
{[Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}