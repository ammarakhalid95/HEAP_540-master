﻿using HEAP_540.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HEAP_540.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext context;

        //GET: Roles
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public RolesController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);

        }
        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "IT Administrator")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}