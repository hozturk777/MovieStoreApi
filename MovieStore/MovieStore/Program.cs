using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MovieStore.DbOperations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<MovieContext>(options => options.UseInMemoryDatabase(databaseName :"MovieDB"));
builder.Services.AddDbContext<MovieContext>();
builder.Services.AddScoped<IMovieContext, MovieContext>();
//builder.Services.AddScoped<IMovieContext>(provider => provider.GetService<MovieContext>());
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//  .NET 6.0
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    DataGenerator.Initialize(services);
}
//  .NET 5.0
//var host = CreateHostBuilder(args).Build();

//using (var scope = host.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    DataGenerator.Initialize(services);
//}
//host.Run();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRazorPages();


app.MapControllers();

app.Run();
