
namespace projectOneWithMongo.Services
{
    public class TodoItemDto
    {
        public string task { get; set; } 
        
        public bool completed { get; set; }
        
        public string userID { get; set; }
    }
}
