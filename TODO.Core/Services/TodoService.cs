using TODO.Core.Models;
using TODO.Core.Services.Contracts;
using TODO.Data;
using TODO.Data.Models;

namespace TODO.Core.Services
{
    public class TodoService : ITodoService
    {
        private TodoContext _DbContext { get; set; }
        public TodoService(TodoContext context)
        {
            _DbContext = context;
        }
        public bool AddTodo(Todo item)
        {
            var todo = new TodoItem { CreatedEmail = "", Description = item.Description, Title = item.Title };
            var a = _DbContext.Todos.Add(todo);
            _DbContext.SaveChanges();
            if (a.Entity.Id>0)
                return true;
            else
                return false;
        }

        public Todo GetTodoById(int id)
        {
            var item= _DbContext.Todos.FirstOrDefault(_=> _.Id == id);
            if (item is not null)
            {
                return new Todo { Description = item.Description, Title = item.Title, Id = item.Id, IsCompleted = item.IsCompleted };
            }
            else return default;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _DbContext.Todos.ToList().Select(_ =>
            {
                return new Todo { Description = _.Description, Title = _.Title, Id = _.Id, IsCompleted = _.IsCompleted };
            });
        }

        public bool UpdateTodo(Todo item)
        {
            var todo = _DbContext.Todos.FirstOrDefault(_ => _.Id == item.Id);
            if (todo != null)
            {
                todo.IsCompleted = item.IsCompleted;
                todo.Description = item.Description;
                todo.Title = item.Title;
                todo.ModifiedOn= DateTime.UtcNow;
                todo.ModifiedEmail = "";
                _DbContext.Todos.Update(todo);
                _DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteTodo(int id)
        {
            var todo = _DbContext.Todos.FirstOrDefault(_ => _.Id == id);
            _DbContext.Todos.Remove(todo);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
