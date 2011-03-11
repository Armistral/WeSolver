using WeSolver.Registration;
using System.Configuration;

namespace WeSolver.Facebook
{
    public class FacebookSettings : ConfigurationSection , IRegistrationSettings
    {
        [ConfigurationProperty("appId", IsRequired = true)]
        public string AppId
        {
            get { return (string)this["appId"]; }
            set { this["appId"] = value; }
        }

        [ConfigurationProperty("appSecret", IsRequired = true)]
        public string AppSecret
        {
            get { return (string)this["appSecret"]; }
            set { this["appSecret"] = value; }
        }

        [ConfigurationProperty("siteUrl", IsRequired = false)]
        public string SiteUrl
        {
            get { return (string)this["siteUrl"]; }
            set { this["siteUrl"] = value; }
        }

        [ConfigurationProperty("CancelUrlPath", IsRequired = false)]
        public string CancelUrlPath
        {
            get { return (string)this["cancelUrlPath"]; }
            set { this["cancelUrlPath"] = value; }
        }
    }
}
