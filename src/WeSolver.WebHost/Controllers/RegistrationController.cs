using System.Configuration;
using System.Web.Mvc;
using WeSolver.Data;
using WeSolver.Facebook;
using WeSolver.Registration;

namespace WeSolver.WebHost.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            SignedUser signedUser = null;

            if (Request["signed_request"] != null)
            {
                var signedRequest = Request["signed_request"];
                var facebookValidation = new ValidateRegistration();
                var settings = (FacebookSettings)ConfigurationManager.GetSection("facebookSettings");
                signedUser = facebookValidation.TryValidate(settings, signedRequest);
            }

            if (signedUser != null)
            {
                var user = new WeSolverUser { FacebookUid = signedUser.UserId, Email = signedUser.Email };
                var ds = new WeSolverDataSource();
                ds.AddUser(user);
                System.Diagnostics.Trace.TraceInformation("Added user {0}-{1} in table storage for user '{2}'", user.PartitionKey, user.RowKey, user.FacebookUid);
            }

            return RedirectToAction("index", "home");
        }
    }
}
