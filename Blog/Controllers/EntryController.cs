﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEntry()
        {
            return View();
        }

        public ActionResult EditEntry()
        {
            return View();
        }
    }
}