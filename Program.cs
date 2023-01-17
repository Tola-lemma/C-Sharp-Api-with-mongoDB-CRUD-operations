using MongoDB.Driver;
using projectOneWithMongo.Models;
using projectOneWithMongo.Repository;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDBsettings>(
      builder.Configuration.GetSection("MongoDBSettings")
    );
//mongodatabase entity
//IMongoDatabase as singleton
builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var mongosetting = builder.Configuration.GetSection("mongoDBSetting").Get<MongoDBsettings>();
    var client = new MongoClient(mongosetting.ConnectionString);
    return client.GetDatabase(mongosetting.DatabaseName);
});
builder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
