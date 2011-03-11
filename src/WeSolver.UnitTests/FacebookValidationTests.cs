using NUnit.Framework;
using WeSolver.Facebook;
using WeSolver.Registration;

namespace WeSolver.UnitTests
{
    [TestFixture]
    public class FacebookValidationTests
    {
        //test signed request from dev docs http://developers.facebook.com/docs/authentication/signed_request/
        private const string SignedRequest = "vlXgu64BQGFSQrY0ZcJBZASMvYvTHu9GQ0YM9rjPSso.eyJhbGdvcml0aG0iOiJITUFDLVNIQTI1NiIsIjAiOiJwYXlsb2FkIn0";
        private const string TestSecret = "secret";

        [Test]
        public void ValidSignedRequest()
        {
            var settings = new FacebookSettings { AppSecret = TestSecret };

            var facebookValidation = new ValidateRegistration();

            SignedUser signedUser = facebookValidation.TryValidate(settings, SignedRequest);

            Assert.That(signedUser != null, "signed request was not decoded correctly");

        }

        [Test]
        public void InValidSignedRequest()
        {
            var settings = new FacebookSettings { AppSecret = "shhhhhh" };

            var facebookValidation = new ValidateRegistration();

            SignedUser signedUser = facebookValidation.TryValidate(settings, SignedRequest);

            Assert.That(signedUser == null, "signed request should have failed");

        }
    }
}
