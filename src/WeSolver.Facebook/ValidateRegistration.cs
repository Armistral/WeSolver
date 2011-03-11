using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeSolver.Registration;
using System.Web.Script.Serialization;

namespace WeSolver.Facebook
{
    public class ValidateRegistration : IValidateRegistration
    {
        private readonly JavaScriptSerializer _ser = new JavaScriptSerializer();

        /// <summary>
        /// Based on the PHP example from docs http://developers.facebook.com/docs/plugins/registration/ and http://facebooksdk.codeplex.com
        /// </summary>
        /// <param name="settings">Facebook app settings</param>
        /// <param name="providerSignedRequest">Facebook signed request sent after registration</param>
        /// <returns>bool</returns>
        public SignedUser TryValidate(IRegistrationSettings settings, string providerSignedRequest)
        {
            //TODO registration should be done using HTTPS

            SignedUser signedUser = null;

            var signedParts = providerSignedRequest.Split('.');

            if (signedParts.Count() != 2)
            {
                return signedUser;
            }

            var payload = Encoding.UTF8.GetString(FacebookUtils.Base64UrlDecode(signedParts[1]));

            var data = (Dictionary<string, object>)_ser.Deserialize(payload, typeof(Dictionary<string, object>));

            if (data == null || !data.ContainsKey("algorithm"))
            {
                return signedUser;
            }

            var algorithm = (string)data["algorithm"];

            if (string.IsNullOrEmpty(algorithm) || algorithm.ToUpper() != "HMAC-SHA256")
            {
                return signedUser; // TODO: log unsupported algorithm
            }

            var expectedSigBytes = FacebookUtils.HashHmac(Encoding.UTF8.GetBytes(signedParts[1]), Encoding.UTF8.GetBytes(settings.AppSecret));
            var sigBytes = FacebookUtils.Base64UrlDecode(signedParts[0]);

            var expectedSig = Encoding.UTF8.GetString(expectedSigBytes);
            var sig = Encoding.UTF8.GetString(sigBytes);

            if (sig != expectedSig)
            {
                return signedUser;//TODO log these
            }

            signedUser = new SignedUser();

            signedUser.UserId = data.ContainsKey("user_id") ? (string)data["user_id"] : null;
            signedUser.IssuedAtUtc = data.ContainsKey("issued_at") ? FacebookUtils.ParseUnixTime((int)data["issued_at"]): DateTime.Now;

            return signedUser;
        }
    }
}
