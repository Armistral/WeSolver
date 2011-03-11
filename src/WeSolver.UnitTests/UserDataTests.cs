using Microsoft.WindowsAzure;
using NUnit.Framework;
using WeSolver.Data;

namespace WeSolver.UnitTests
{
    [TestFixture, Category("integration")]
    public class UserDataTests
    {
        private WeSolverDataSource _dataSource;

        [TestFixtureSetUp]
        public void Setup()
        {
            //local storage emulator needs to be running for these integration tests to work
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => configSetter("UseDevelopmentStorage=true"));
            _dataSource = new WeSolverDataSource();
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            var ds = new WeSolverDataSource();
            ds.DeleteUser("191921");
            ds.DeleteUser("8178172");
        }

        [Test]
        public void SaveUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "191921", Email = "jsonrow@somewhere.com" };
            _dataSource.AddUser(testUser);

            Assert.That(_dataSource.GetWeSolverUser("191921") != null, "save is not working");
        }

        [Test]
        public void DeleteUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "8178172", Email = "jsonrow@somewhere.com" };

            _dataSource.AddUser(testUser);

            Assert.That(_dataSource.GetWeSolverUser("8178172") != null, "save is not working");

            _dataSource.DeleteUser("8178172");

            Assert.That(_dataSource.GetWeSolverUser("8178172") == null, "delete is not working");
        }

        [Test]
        public void UpdateUser()
        {
            var testUser = new WeSolverUser { FacebookUid = "8178172", Email = "jsonrow@somewhere.com" };

            _dataSource.AddUser(testUser);

            testUser.Bio = "@markrendle is cool";

            _dataSource.UpdateUser(testUser);
            
            var result = _dataSource.GetWeSolverUser("8178172");

            Assert.That(result.Bio == "@markrendle is cool", "update didn't work");
        }
    }
}
