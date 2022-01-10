using Library.DAL.Interfaces;
using Library.Models;
using Moq;
using System;
using System.Collections.Generic;

namespace Library.Services.Tests
{
    public abstract class TopServiceSetup
    {
        protected Mock<IRepository<Book>> mockRepository;
        protected TopService service;
        protected List<Book> books;
        protected List<Book> booksEmpty;
        protected List<Book> booksNull;
        public TopServiceSetup()
        {
            SetUpConfig();
            booksEmpty = new List<Book>();
            booksNull = null;
        }
        public void SetUpConfig()
        {
            mockRepository = new Mock<IRepository<Book>>();
            service = new TopService(mockRepository.Object);
            books = new List<Book>()
            {
                new Book { Id = new Guid("DABB7DFB-5004-4BD4-9ECC-EA07FA448A39"), Title = "Nerve", Category = "utopy", Author = "Jeanne Ryan" },
                new Book { Id = new Guid("1F414F35-1A8E-472E-A832-96CE6E688650"), Title = "Requiem", Category = "romance", Author = "Lauren Oliver" },
                new Book { Id = new Guid("F55EB00C-F99A-4C89-B9E1-2AB739C77080"), Title = "Delirium", Category = "romance", Author = "Lauren Oliver" },
            };
        }
    }
}
