using System;
using Library.DAL.Interfaces;
using Library.Models;
using Library.Services.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.Services
{
    public class TopService :IService<Book>
    {
        private readonly IRepository<Book> repository;
        public TopService(IRepository<Book> repository)
        {
            this.repository = repository;
        }
        public List<Book> GetTop(int quantity)
        {
            var list = repository.Get(quantity);
            return list;
        }
    }
}
