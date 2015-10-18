using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public interface IBooksRepository
    {
        IEnumerable GettAll();
        Book Get(int id);
        Book Add(Book item);
        void Remove(int it);
    }
}