using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;

namespace WeSolver.Data
{
    public class WeSolverDataContext : Microsoft.WindowsAzure.StorageClient.TableServiceContext
    {
        public WeSolverDataContext(string baseAddress, StorageCredentials credentials) : base(baseAddress, credentials)
        {
        }

        public IQueryable<WeSolverUser> WeSolverUser
        {
            get
            {
                return this.CreateQuery<WeSolverUser>("WeSolverUser");
            }
        }
    }
}
