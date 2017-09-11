using System;
using System.Collections.Generic;

namespace StudentApp.Interfaces
{
    interface IRepository<T> : IDisposable where T:class
    {   
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        void Save();
    }
}
