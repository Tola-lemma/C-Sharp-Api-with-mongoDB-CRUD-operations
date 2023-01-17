using MongoDB.Driver;
using projectOneWithMongo.Services;

namespace projectOneWithMongo.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly IMongoCollection<TodoItem> _mongoTodoItemServices;
        //Inject
        public TodoItemRepository(IMongoDatabase mongoDatabase)
        {
            _mongoTodoItemServices = mongoDatabase.GetCollection<TodoItem>("Todo");
        }
        //fetching data from mongoDB
        public async Task<List<TodoItem>> GetAllAsync() => await _mongoTodoItemServices.Find(_ => true).ToListAsync(); 
        
        public async Task CreateAsync(TodoItem newtodoitem) => await _mongoTodoItemServices.InsertOneAsync(newtodoitem);
        
        public async Task<TodoItem> GetByIdAsync(string id)
        {
          return await _mongoTodoItemServices.Find(_=>_.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(TodoItem todoItemUpdate)
        {
             await _mongoTodoItemServices.ReplaceOneAsync(_=>_.Id == todoItemUpdate.Id, todoItemUpdate);
        }
    public async Task DeleteAsync(string id)
        {
            await _mongoTodoItemServices.DeleteOneAsync(_=>_.Id == id); 
        }
    }
}
