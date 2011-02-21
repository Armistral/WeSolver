using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeSolver.Registration;

namespace WeSolver.Facebook
{
    public class FacebookSignedUser : ISignedUser
    {
        public string UserId { get; set; }

        public DateTime IssuedAtUtc { get; set; }
    }
}
