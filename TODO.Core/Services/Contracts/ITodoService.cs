using TODO.Core.Models;

namespace TODO.Core.Services.Contracts
{
    public interface ITodoService
    {
        public IEnumerable<Todo> GetTodos();
        public Todo GetTodoById(int id);
        public bool AddTodo(Todo item);
        public bool UpdateTodo(Todo item);
        public bool DeleteTodo(int id);
    }
}
