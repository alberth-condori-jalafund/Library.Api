using System;
using System.Collections.Generic;

namespace Library.Services.Interfaces
{
    public interface IService <T> 
    {
        List<T> GetTop(int quantity);
    }
}
