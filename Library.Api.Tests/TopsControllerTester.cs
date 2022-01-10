using Library.Api.Messages;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Library.Api.Tests
{
    public class TopsControllerTester : TopsControllerSetup
    {
        [Fact]
        public void Top_Sucess_TenBookList200Code()
        {
            const int topTen = 10;

            mockService.Setup(service => service.GetTop(topTen)).Returns(books);
            var response = controller.Top();
            ObjectResult okObjectResult = response as ObjectResult;

            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(topTen, (okObjectResult.Value as List<Book>).Count);
        }
        [Fact]
        public void Top_NoBooksFound_NotFound204Code()
        {
            const int topTen = 10;
            const string message = "Nothing to show on top";

            mockService.Setup(service => service.GetTop(topTen)).Returns(new List<Book>());
            var response = controller.Top();
            ObjectResult badObjectResult = response as ObjectResult;

            Assert.Equal(204, badObjectResult.StatusCode);
            Assert.Equal(message, (badObjectResult.Value as ErrorMessage).Message);
        }
        [Fact]
        public void Top_BadEntry_BadRequest400Code()
        {
            const string message = "Bad top entry";

            mockService.Setup(service => service.GetTop(-10)).Returns(new List<Book>());
            controller.top = -10;
            var response = controller.Top();
            ObjectResult badObjectResult = response as ObjectResult;

            Assert.Equal(400, badObjectResult.StatusCode);
        }
        [Fact]
        public void Top_SqlException_RepositoryError500Code()
        {
            Exception exception = new Exception("", new Exception(""));
            mockService.Setup(service => service.GetTop(10)).Throws(exception);
            var response = controller.Top();
            ObjectResult badObjectResult = response as ObjectResult;

            Assert.Equal(500, badObjectResult.StatusCode);
        }
    }
}
