using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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
        /// <summary>
        /// Возвращает все книги которые есть в базе
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Book>))]
        public async Task<IHttpActionResult> Get()
        {
            var books = await _repository.GettAllAsync();
            return Ok(books);
        }
        /// <summary>
        /// Возвращает конкретную книгу
        /// </summary>
        /// <param name="id">Id книги</param>
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
        /// Добавляет книгу
        /// </summary>
        /// <param name="item"></param>
        /// <returns>201 и урл с айдишкой книги</returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostBook([FromBody] Book item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedItem = await _repository.AddAsync(item);
            return Ok(addedItem);
        }
        /// <summary>
        /// Удаляет из базы книгу
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns>200 если успешно удалило или 404 если не нашло</returns>
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
        /// Обновляет значения которые пришли из тела
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
        /// <summary>
        /// Возвращает картинку книги по Id 
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/books/picture/{id}")]
        public async Task<HttpResponseMessage> GetPicture(int id)
        {
            var data = await _repository.GetAsync(id);
            if (data != null)
            {
                byte[] imgData = data.ImageOfBook;
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(ms) };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

    }
}
