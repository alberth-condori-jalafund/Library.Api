using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Library.Services.Tests
{
    public class TopServiceTester : TopServiceSetup
    {
        [Fact]
        public void GetTop_Quantity3_BookList()
        {
            int top = 3;
            int excpected = 3;

            mockRepository.Setup(repository => repository.Get(top)).Returns(books);
            var response = service.GetTop(top);

            Assert.Equal(excpected, response.Count);
        }
        [Fact]
        public void GetTop_EmptyListBook_Exception()
        {
            int top = 3;
            int excpected = 0;

            mockRepository.Setup(repository => repository.Get(top)).Returns(booksEmpty);
            var response = service.GetTop(top);

            Assert.Equal(excpected, response.Count);
        }
        [Fact]
        public void GetTop_NullList_BookList()
        {
            int top = 3;
            List<Book> excpected = null;

            mockRepository.Setup(repository => repository.Get(top)).Returns(booksNull);
            var response = service.GetTop(top);

            Assert.Equal(excpected, response);
        }
    }
}
