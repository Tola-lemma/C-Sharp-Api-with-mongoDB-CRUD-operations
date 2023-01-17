using projectOneWithMongo.Services;

namespace projectOneWithMongo.Repository
{
    public interface ITodoItemRepository
    {
        //method definition
        Task<List<TodoItem>> GetAllAsync();
        Task CreateAsync(TodoItem todo);
        Task<TodoItem> GetByIdAsync(string id);
        Task UpdateAsync(TodoItem todoItemUpdate);
        Task DeleteAsync(string id);
    }
}
