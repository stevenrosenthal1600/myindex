using CodeChallenge.Models;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Contracts;

namespace CodeChallenge.Tests.Integration.Controllers
{
    [TestClass]
    public class CompensationControllerTests : BaseControllerTests
    {
        [TestMethod]
        public void CreateCompensation_Paul_Returns_Created()
        {
            // Arrange
            var employeeId = "b7839309-3348-463b-a7e3-5de1c168beb3";
            var expectedFirstName = "Paul";
            var expectedLastName = "McCartney";
            var expectedSalary = 150000;
            var compensation = new CompensationStructure
            {
                EmployeeId = employeeId,
                Salary = expectedSalary
            };
            var requestContent = new JsonSerialization().ToJson(compensation);

            // Execute
            var postRequestTask = _httpClient.PostAsync("api/compensation",
               new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var response = postRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var newCompensation = response.DeserializeContent<CompensationStructure>();
            Assert.AreEqual(expectedFirstName, newCompensation.Employee.FirstName);
            Assert.AreEqual(expectedLastName, newCompensation.Employee.LastName);
            Assert.AreEqual(expectedSalary, newCompensation.Salary);
            Assert.AreEqual(DateTime.UtcNow.Date, newCompensation.EffectiveDate);
        }
    }
}
