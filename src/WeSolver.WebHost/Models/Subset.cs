using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeSolver.WebHost.Models
{
    public class Subset<T>
    {
        public int Index { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }

        // public XmlQualifiedName SortBy { get; set; }
        // public bool Descending { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}