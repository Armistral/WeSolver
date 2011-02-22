using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeSolver.WebHost.Models;

namespace WeSolver.WebHost.Controllers
{
    public class ProblemController : Controller
    {
        //
        // GET: /Problem/

        public ActionResult Detail()
        {
            var problem = new Problem
            {
                Title = "Problem 0",
                Detail = "Something something",
                Solutions = new Subset<Solution>
                {
                    Items = new List<Solution>
                    {
                        new Solution
                        {
                            Title = "WeSolver",
                            Detail = "<p>This site</p>"
                        }
                    }
                }
            };

            return View(problem);
        }

    }
}
