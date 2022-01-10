using System;
using System.Collections.Generic;

namespace Library.DAL.Interfaces
{
    public interface IRepository <T>
    {
        public List<T> Get(int quantity);
    }
}
