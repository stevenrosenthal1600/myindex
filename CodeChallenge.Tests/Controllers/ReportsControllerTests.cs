using CodeChallenge.Contracts;
using CodeCodeChallenge.Tests.Integration.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace CodeChallenge.Tests.Integration.Controllers
{
    [TestClass]
    public class ReportsControllerTests : BaseControllerTests
    {
        [TestMethod]
        public void GetNumberOfReports_JohnLennon_Returns_Ok()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var expectedFirstName = "John";
            var expectedLastName = "Lennon";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reports/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var reports = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(expectedFirstName, reports.Employee.FirstName);
            Assert.AreEqual(expectedLastName, reports.Employee.LastName);
            Assert.AreEqual(reports.NumberOfReports, 4);
        }

        [TestMethod]
        public void GetNumberOfReports_RingoStarr_Returns_Ok()
        {
            // Arrange
            var employeeId = "03aa1462-ffa9-4978-901b-7c001562cf6f";
            var expectedFirstName = "Ringo";
            var expectedLastName = "Starr";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reports/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var reports = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(expectedFirstName, reports.Employee.FirstName);
            Assert.AreEqual(expectedLastName, reports.Employee.LastName);
            Assert.AreEqual(reports.NumberOfReports, 2);
        }
    }
}
