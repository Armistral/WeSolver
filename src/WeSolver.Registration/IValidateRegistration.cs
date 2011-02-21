using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeSolver.Registration
{
    public interface IValidateRegistration
    {
        bool TryValidate(IRegistrationSettings settings, string providerSignedRequest, out ISignedUser signedUser);
    }
}
