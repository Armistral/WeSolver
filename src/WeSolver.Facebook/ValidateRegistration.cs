using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeSolver.Registration;

namespace WeSolver.Facebook
{
    class ValidateRegistration : IValidateRegistration
    {

        public bool TryValidate(IRegistrationSettings settings, string providerSignedRequest, out ISignedUser signedUser)
        {
            //TODO decrypt provider request and match with secret key in settings.

            //TODO If valid, return SignedUser
            throw new NotImplementedException();
        }
    }
}
