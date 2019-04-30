using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAAnywhereUI.Models;

namespace TAAnywhereUI.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(ThemeModel strModel)
        {
            return View(strModel);
        }
    }
}