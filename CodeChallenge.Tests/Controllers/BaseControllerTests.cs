using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace CodeChallenge.Tests.Integration.Controllers
{
    [TestClass]
    public class BaseControllerTests
    {
        protected static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        // Attribute ClassInitialize requires this signature
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }
    }
}
