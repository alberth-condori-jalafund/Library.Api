using Library.Services.Interfaces;
using Library.Api.Controllers;
using Library.Models;
using Moq;
using System;
using System.Collections.Generic;

namespace Library.Api.Tests
{
    public abstract class TopsControllerSetup
    {
        protected Mock<IService<Book>> mockService;
        protected TopsController controller;
        protected List<Book> books;
        public TopsControllerSetup()
        {
            SetUpConfig();
        }
        public void SetUpConfig()
        { 
            mockService = new Mock<IService<Book>>();
            controller = new TopsController(mockService.Object);
            books = new List<Book>() 
            { 
                new Book { Id = new Guid("DABB7DFB-5004-4BD4-9ECC-EA07FA448A39"), Title = "Nerve", Category = "utopy", Author = "Jeanne Ryan" },
                new Book { Id = new Guid("1F414F35-1A8E-472E-A832-96CE6E688650"), Title = "Requiem", Category = "romance", Author = "Lauren Oliver" },
                new Book { Id = new Guid("F55EB00C-F99A-4C89-B9E1-2AB739C77080"), Title = "Delirium", Category = "romance", Author = "Lauren Oliver" },
                new Book { Id = new Guid("3D399A94-012B-4D70-B645-22ECFD9FEAE2"), Title = "Pandemonium", Category = "romance", Author = "Lauren Oliver" },
                new Book { Id = new Guid("0535D4A4-35A5-47E0-8DFE-7DF20ED07FEB"), Title = "Cumbres borrascosas", Category = "romance", Author = "Emily Bronte" },
                new Book { Id = new Guid("1921F29F-A148-4007-9DF8-0562962FDF4C"), Title = "Dr. Jekelly and Mr Hyde", Category = "terror", Author = "R.L. Stevenson" },
                new Book { Id = new Guid("2C52708B-78CC-4656-8209-28C201C4EADE"), Title = "Renueva tus neuronas", Category = "helping", Author = "Marcos Witt" },
                new Book { Id = new Guid("2A276426-7663-4578-A105-D931A1F12FBF"), Title = "Siete dias en junio", Category = "romance", Author = "Tia Williams" },
                new Book { Id = new Guid("BD3D72B0-CDED-4828-A782-83F6C00A2B7C"), Title = "El amor en los tiempos de colera", Category = "romance", Author = "Gabriel Garcia M." },
                new Book { Id = new Guid("EFE5B17A-A001-4AB1-8084-E58EE01C0933"), Title = "bluescreen", Category = "utopy", Author = "Dan Wells" }
            };
        }
    }
}
