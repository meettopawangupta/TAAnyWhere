using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAAnywhereUI.Models;

namespace TAAnywhereUI.Controllers.Theme
{ 
    public class ThemeController : Controller
    {
        // GET: Theme
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Login","Login", new ThemeModel() { ThemeName = "primary" });// View("Login/Login",new ThemeModel() { Name ="primary" });
        }
    }
}