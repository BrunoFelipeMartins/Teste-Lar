using WebApiLar.Domain.Repository;
using WebApiLar.Infra.Database;
using WebApiLar.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container.

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
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

app.UseCors(option =>{
        option.AllowAnyOrigin();
        option.AllowAnyMethod();
        option.AllowAnyHeader();
        });

//app.UseAuthorization();

app.MapControllers();

app.Run();
