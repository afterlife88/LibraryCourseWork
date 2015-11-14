using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// Book api
    /// </summary>
    public class BooksController : ApiController
    {
        private readonly IBooksRepository _repository;
        public BooksController() : this(new BooksRepository()) { }
        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
        }
        //[Route("api/books/odata")]
        //[HttpGet]
        //[EnableQuery]
        //[ResponseType(typeof(IEnumerable<Book>))]
        //public IQueryable<Book> AllBooksQueryable()
        //{

        //    return _repository.GetAllBooksOdata();
        //}
        /// <summary>
        /// Return all books form db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Book>))]
        public async Task<IHttpActionResult> Get()
        {
            var books = await _repository.GettAllAsync();
            return Ok(books);
        }
        [HttpGet]
        [Route("api/books/orderdsc")]
        public async Task<IHttpActionResult> GetByAsc()
        {
            var books = await _repository.GetOrderByAsc();
            return Ok(books);
        }
        /// <summary>
        /// Return concrete book
        /// </summary>
        /// <param name="id">Id book</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _repository.GetAsync(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="item"></param>
        /// <returns>201 и with url id</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostBook([FromBody] Book item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedItem = await _repository.AddAsync(item);
            return Ok(addedItem);
        }
        /// <summary>
        /// Delete book from db
        /// </summary>
        /// <param name="id">Id bok</param>
        /// <returns>200 if delete 404 if notfound</returns>
        [HttpDelete]
        [Route("api/books/removebook/{id}")]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            var item = await _repository.GetAsync(id);
            if (item != null)
                await _repository.RemoveAsync(item);
            else
                return NotFound();
            return Ok();
        }
        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] Book item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateItem = await _repository.UpdateAsync(item);
            if (updateItem == null) return NotFound();
            return Ok(updateItem);
        }
        //[HttpGet]
        //[Route("api/books/picture/{id}")]
        //public async Task<HttpResponseMessage> GetPicture(int id)
        //{
        //    var data = await _repository.GetAsync(id);
        //    if (data != null)
        //    {
        //        byte[] imgData = data.ImageOfBook;
        //        MemoryStream ms = new MemoryStream(imgData);
        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(ms) };
        //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //        return response;
        //    }
        //    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        //}

    }
}
