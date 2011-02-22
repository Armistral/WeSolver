using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeSolver.WebHost.Models
{
    public class Problem
    {
        public string Title { get; set; }
        public string Detail { get; set; }

        public Subset<Solution> Solutions { get; set; }

        // public XmlQualifiedName Scale { get; set; }
        // public XmlQualifiedName Priority { get; set; }
        // public Subset<Tag> Tags { get; set; }
        // public Subset<Discussion> Discussions { get; set; }
        // public Subset<Reference> References { get; set; }
    }
}