using System;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace WeSolver.Data
{
    public class WeSolverDataSource
    {
        private static readonly CloudStorageAccount StorageAccount;
        private readonly WeSolverDataContext _context;

        static WeSolverDataSource()
        {
            StorageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            CloudTableClient.CreateTablesFromModel(
                typeof(WeSolverDataContext),
                StorageAccount.TableEndpoint.AbsoluteUri,
                StorageAccount.Credentials);
        }

        public WeSolverDataSource()
        {
            _context = new WeSolverDataContext(StorageAccount.TableEndpoint.AbsoluteUri, StorageAccount.Credentials);
            _context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        }

        public WeSolverUser GetWeSolverUser(string facebookUid)
        {
            if (string.IsNullOrEmpty(facebookUid))
            {
                return null;
            }

            return _context.WeSolverUser.Where(user => user.FacebookUid == facebookUid).ToList().FirstOrDefault();
        }

        public void AddUser(WeSolverUser user)
        {
            if (user == null)
            {
                return;
            }

            var exsistingUser = GetWeSolverUser(user.FacebookUid);

            if (exsistingUser == null)
            {
                _context.AddObject("WeSolverUser", user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(WeSolverUser user)
        {
            if (user == null)
            {
                return;
            }

            _context.UpdateObject(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string facebookUid)
        {
            if (string.IsNullOrEmpty(facebookUid))
                return;

            _context.DeleteObject(GetWeSolverUser(facebookUid));
            _context.SaveChanges();
        }
    }
}
