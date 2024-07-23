using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_API.Models;
using ToDo_API.ViewModels;

namespace ToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDBContext _db;
        public ToDoController(ToDoDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<List<ToDo>> GetTos()
        {
            return Ok(_db.ToDos.ToList());
        }

        [HttpPost]
        public ActionResult<List<ToDo>> PostToDO(TodoViewModel todo)
        {
            ToDo todoDb = new ToDo();
            todoDb.Task = todo.Task;
            todoDb.Description = todo.Description;
            todoDb.Status = todo.Status;
            todoDb.Duration = todo.Duration;
            _db.ToDos.Add(todoDb);
            _db.SaveChanges();
            return Ok(_db.ToDos.ToList());
        }
        [HttpPut]
        public ActionResult<List<ToDo>> EditTodo(int id, TodoViewModel Todo)
        {
            var todoDb = _db.ToDos.Where(x => x.Id == id).FirstOrDefault();
            if (todoDb != null)
            {
                todoDb.Task = Todo.Task;
                todoDb.Description = Todo.Description;
                todoDb.Status = Todo.Status;
                todoDb.Duration = Todo.Duration;
                _db.SaveChanges();
            }
            return Ok(_db.ToDos.ToList());
        }
        [HttpDelete]
        public ActionResult<List<ToDo>> DeleteTodo(int id)
        {
            var todoDb = _db.ToDos.Where(x => x.Id == id).FirstOrDefault();
            if(todoDb  != null)
            {
                _db.ToDos.Remove(todoDb);
                _db.SaveChanges();
            }
            return Ok(_db.ToDos.ToList());
        }
    }
}
