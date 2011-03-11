using Microsoft.WindowsAzure;
using NUnit.Framework;
using WeSolver.Data;

namespace WeSolver.UnitTests
{
    [TestFixture, Category("integration")]
    public class UserDataTests
    {
        [SetUp]
        public void Setup()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter("UseDevelopmentStorage=true");
            });
        }

        [Test]
        public void SaveUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "191921", Email = "jsonrow@somewhere.com" };
            var ds = new WeSolverDataSource();
            ds.AddUser(testUser);

            Assert.That(ds.GetWeSolverUser("191921") != null, "save is not working");
        }

        [Test]
        public void DeleteUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "8178172", Email = "jsonrow@somewhere.com" };

            var ds = new WeSolverDataSource();
            ds.AddUser(testUser);

            Assert.That(ds.GetWeSolverUser("8178172") != null, "save is not working");

            ds.DeleteUser("8178172");

            Assert.That(ds.GetWeSolverUser("8178172") == null, "delete is not working");
        }

        [Test]
        public void UpdateUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "8178172", Email = "jsonrow@somewhere.com" };

            var ds = new WeSolverDataSource();
            ds.AddUser(testUser);

            testUser.Bio = "@markrendle is cool";

            ds.UpdateUser(testUser);

            var result = ds.GetWeSolverUser("8178172");

            Assert.That(result.Bio == "@markrendle is cool", "update didn't work");
        }
    }
}
