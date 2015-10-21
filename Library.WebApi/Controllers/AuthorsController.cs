using System.Threading.Tasks;
using System.Web.Http;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;

namespace Library.WebApi.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IAuthorsRepository _repository;
       
        public AuthorsController() : this(new AuthorsRepository()) { }

        public AuthorsController(IAuthorsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var books = await _repository.GettAllAsync();
            return Ok(books);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _repository.GetAsync(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpGet]
        [Route("api/authors/authorbooks/{id}")]
        public async Task<IHttpActionResult> GetBooksByAuthor(int id)
        {
            var data = await _repository.GetBooksByAuthor(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}
