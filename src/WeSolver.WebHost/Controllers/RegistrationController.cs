using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeSolver.WebHost.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Request["signed_request"] != null)
            {
                var signedRequest = Request["signed_request"];
            }

            //TODO verify signed_request parameter from facebook
            //TODO if valid setup user account in our DB using UID and email

            return RedirectToAction("index", "home");
        }
    }
}
