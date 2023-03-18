using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MyProject.Catalog.Service.Repositories;
using MyProject.Catalog.Service.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Make mongo db Guid stored as string
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String)); // Make mongo db DateTime stored as string

//Getting Settings values 
var serviceSettings = new ServiceSettings();
var mongoDbSettings = new MongoDbSettings();

/*builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ServiceSettings"));
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
*/

builder.Services.AddScoped<IItemsRepository, ItemsRepository>(); //Dependency Injection
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
