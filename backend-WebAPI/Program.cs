using System.Xml.Linq;
using backend_WebAPI;
using backend_WebAPI.LocalDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("Students", (string? name, int? age) =>
{
List<object> stus = new();
    stus.Add(new
    {
        Name = name,
        Age = age
    }
);
    return Results.Ok(stus);
});

app.MapGet("Search", (int id) =>
{
    List<Student> stus = new List<Student>();
    JsonOperator json = new JsonOperator();
    stus = JsonOperator.ReadJsonFileToList("LocalDatabase/Student.json");
    
    return Results.Ok(stus.Find(
        delegate (Student student) { return student.id == id; }
        )

        );
});
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();