using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeSolver.Registration
{
    public interface ISignedUser
    {
        string UserId { get; set; }

        DateTime? IssuedAtUtc { get; set; }
    }
}
