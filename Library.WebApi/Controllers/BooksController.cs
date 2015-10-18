using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.WebApi.Data;

namespace Library.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBooksRepository _repository;
        public BooksController() : this(new BooksRepository()) { }

        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
        }
        public IHttpActionResult Get()
        {
            var books = _repository.GettAll();
            return Ok(books);
        }
    }
}
