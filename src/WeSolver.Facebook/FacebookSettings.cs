using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeSolver.Registration;

namespace WeSolver.Facebook
{
    public class FacebookSettings : IRegistrationSettings
    {

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public string SiteUrl { get; set; }

        public string CancelUrlPath { get; set; }

    }
}
