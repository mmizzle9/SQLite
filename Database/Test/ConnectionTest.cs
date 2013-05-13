using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;
using Database.ViewModels;
using Database;
using System.Threading.Tasks;


namespace Test
{
    [TestClass]
    public class ConnectionTest
    {
        CorporationViewModel viewmodel;

        [TestMethod]
        public void TestConnection()
        {
            viewmodel = new CorporationViewModel();
        }

        [TestMethod]
        public void CreateEmployer()
        {
            
            viewmodel = new CorporationViewModel();
            var employer = new Employer { Address = "2425 Nashville Rd", City = "Bowling Green", CompanyName = "Hitcents", State = "KY" };
            
            var task = viewmodel.CreateEmployer(employer);
            task.Wait();
            employer.ID = task.Result;

            var getTask = viewmodel.GetEmployer(employer);
            getTask.Wait();
            var loadedEmployer = getTask.Result;
            Assert.AreEqual(employer.Address, loadedEmployer.Address);
            Assert.AreEqual(employer.City, loadedEmployer.City);
            Assert.AreEqual(employer.CompanyName, loadedEmployer.CompanyName);
            Assert.AreEqual(employer.State, loadedEmployer.State);

            if ( employer.ID > 0)
            {
                var deleteTask = viewmodel.DeleteEmployer(employer);
                deleteTask.Wait();
                Assert.IsNotNull(deleteTask.Result);
            }
        }

        //[TestMethod]
        public void CreateEmployee()
        {
            viewmodel = new CorporationViewModel();
            var employee = new Employee { Address = "1909 Creason St.", City = "Bowling Green", FirstName = "Mitchell", LastName = "Michael" };
            viewmodel.CreateEmployee(employee);
        }
    }
}
