using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectOneWithMongo.Repository;
using projectOneWithMongo.Services;

namespace projectOneWithMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        //inject ITodoItemRepository
        private readonly ITodoItemRepository _todoRepository;
        public TodoItemController(ITodoItemRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        //Action method
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoRepository.GetAllAsync();
            return Ok(todos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var todos = await _todoRepository.GetByIdAsync(id);
            return Ok(todos);
        }
        [HttpPost("Task")]
        public async Task<IActionResult> CreateTask([FromBody] TodoItemDto todoDto)
        {
            if (todoDto == null) { return NotFound(); }
            var item = new TodoItem 
            { 
                completed = todoDto.completed,
                task = todoDto.task, 
                userID = todoDto.userID 
            };
           await _todoRepository.CreateAsync(item);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TodoItem todoItemUpdate)
        {
            var todos = _todoRepository.GetByIdAsync(todoItemUpdate.Id);
            if(todos == null) { return NotFound(); }
            await _todoRepository.UpdateAsync(todoItemUpdate);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var todos = _todoRepository.GetByIdAsync(id);
            if (todos == null) { return NotFound(); }
            await _todoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
