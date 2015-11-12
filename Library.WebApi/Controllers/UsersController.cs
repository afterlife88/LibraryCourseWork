using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository _repository;

        public UsersController() : this(new UserRepository()) { }
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("api/users/{id}")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        /// <summary>
        /// Reg from body
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> RegistrateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regUser = await _repository.RegistrateUser(user);
            return Ok(regUser);
        }
        /// <summary>
        /// add books to user
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="book">object of book</param>
        /// <returns></returns>
        [Route("api/users/addbook/{id}")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBook(int id, [FromBody] Book book)
        {
            var user = await _repository.AddBook(id, book);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [Route("api/users/removebook/{id}")]
        [HttpPost]
        public async Task<IHttpActionResult> RemoveBook(int id, [FromBody] Book book)
        {
            var user = await _repository.RemoveBook(id, book);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        /// <summary>
        /// user validation 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>200 if login, 404 if not found</returns>
        [HttpPut]
        [Route("api/users/validate")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> ValidateUser([FromBody] User user)
        {
            var findeduser = await _repository.ValidateUser(user);
            if (findeduser != null)
            {
                return Ok(findeduser);
            }
            return NotFound();
        }

    }
}
