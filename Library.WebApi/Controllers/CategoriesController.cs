using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Library.WebApi.Data;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// api categories
    /// </summary>
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesRepository _repository;
        public CategoriesController() : this(new CategoriesRepository()) { }
        public CategoriesController(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Возвращает все категории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var items = await _repository.GettAllAsync();

            return Ok(items);
        }
        /// <summary>
        /// Возвращает категорию по id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/categories/{id}")]
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var item = await _repository.GetAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet]
        [Route("api/categories/books/{id}")]
        [ResponseType(typeof(IEnumerable<Book>))]
        public async Task<IHttpActionResult> GetBooksByCategory(int id)
        {
            var data = await _repository.GetBooksByCategoryAsync(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }


    }

}
