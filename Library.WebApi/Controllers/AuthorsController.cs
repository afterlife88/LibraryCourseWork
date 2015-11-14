using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// authors api
    /// </summary>
    public class AuthorsController : ApiController
    {
        private readonly IAuthorsRepository _repository;
        public AuthorsController() : this(new AuthorsRepository()) { }
        public AuthorsController(IAuthorsRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Return all authors in DB
        /// </summary>
        /// <returns>JSON with id, firstName, lastName authors</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Author>))]
        public async Task<IHttpActionResult> Get()
        {
            var books = await _repository.GettAllAsync();
            return Ok(books);
        }

        [Route("api/authors/orderasc")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAsc()
        {
            var books = await _repository.GetOrderByAsc();
            return Ok(books);
        }
        /// <summary>
        /// Get info about concrete author
        /// </summary>
        /// <param name="id">Id author</param>
        /// <returns>JSON с id, firstName, lastName author</returns>
        [HttpGet]
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _repository.GetAsync(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        /// <summary>
        /// Return all books by second name of author
        /// </summary>
        /// <param name="lastName">Last name author</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/authors/books/findbyname/{lastName}")]
        [ResponseType(typeof(IEnumerable<Book>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(string lastName)
        {
            var data = await _repository.GetBooksByAuthor(lastName);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        /// <summary>
        /// Return all books by concrete author
        /// </summary>
        /// <param name="id">Id author</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/authors/books/{id}")]
        [ResponseType(typeof(IEnumerable<Book>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(int id)
        {
            var data = await _repository.GetBooksByAuthor(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        /// <summary>
        /// Add author
        /// </summary>
        /// <param name="item">object of created author</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostAuthor([FromBody]Author item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedItem = await _repository.AddAsync(item);
            return Ok(addedItem);
        }
        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAuthor([FromBody] Author item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var itemToUpdate = await _repository.UpdateAsync(item);
            if (item == null) return NotFound();
            return Ok(itemToUpdate);
        }
        /// <summary>
        /// Delete the author
        /// </summary>
        /// <param name="id">Id автора</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/authors/removeauthor/{id}")]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            var item = await _repository.GetAsync(id);
            if (item != null)
                await _repository.RemoveAsync(id);
            else
                return NotFound();
            return Ok();
        }

    }
}
