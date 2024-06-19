using Microsoft.AspNetCore.Mvc;
using TODO.Core.Models;
using TODO.Core.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TODO.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoService _Service { get; set; }
        public TodoController(ITodoService service)
        {
            _Service= service;
        }
        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return this._Service.GetTodos();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return this._Service.GetTodoById(id);
        }

        // POST api/<TodoController>
        [HttpPost]
        public void Post([FromBody] Todo value)
        {
            this._Service.AddTodo(value);
        }

        // PUT api/<TodoController>/5
        [HttpPut]
        public void Put([FromBody] Todo value)
        {
            this._Service.UpdateTodo(value);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._Service.DeleteTodo(id);
        }
    }
}
