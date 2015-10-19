using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;

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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = _repository.Get(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpGet]
        [Route("api/books/picture/{id}")]
        public HttpResponseMessage GetPicture(int id)
        {
            var data = _repository.Get(id);
            if (data != null)
            {
                byte[] imgData = data.ImageOfBook;
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(ms) };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }
    }
}
