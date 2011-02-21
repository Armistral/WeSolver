using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeSolver.Registration
{
    public interface IRegistrationSettings
    {
        string AppId { get; set; }

        string AppSecret { get; set; }

        string SiteUrl { get; set; }

        string CancelUrlPath { get; set; }
    }
}
