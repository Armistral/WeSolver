using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeSolver.Registration
{
    public class SignedUser
    {
        public string UserId { get; set; }

        public DateTime IssuedAtUtc { get; set; }

        public string Email { get; set; }
    }
}
