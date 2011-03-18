using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace WeSolver.WebHost.Models
{
    public class NavItem
    {
        public string DisplayText { get; set; }
        public string Action { get; set; }
        public RouteValueDictionary Route { get; set; }
        public bool Selected { get; set; }
        public Func<RouteValueDictionary, bool> Condition { get; set; }

        public IList<NavItem> Children { get; set; }
    }
}