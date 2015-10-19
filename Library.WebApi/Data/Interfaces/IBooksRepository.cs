using System.Collections;
using System.Collections.Generic;
using Library.WebApi.Models;

namespace Library.WebApi.Data.Interfaces
{
    public interface IBooksRepository
    {
        IEnumerable GettAll();
        Book Get(int id);
        Book Add(Book item);
        void Remove(int id);
    }
}