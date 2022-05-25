using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;


namespace UserAPI.Tests
{
    public class UserBillTest
    {
        HttpClient SUT;
        WebApplicationFactory<Startup> server;

        [OneTimeSetUp]
        public void SetUp()
        {
            server = new WebApplicationFactory<Startup>();
            SUT = server.CreateClient();
        }
        [OneTimeTearDown]
        public void Clean()
        {
            SUT.Dispose();
        }


        [Test]
        [TestCase(2,"02-2022")]
        public void GetBillTest(int id, string month)
        {
            //Act
            var response = SUT.GetAsync($"http://localhost:18972/UserBill/GetBill?id=2&month=2022-02").Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
