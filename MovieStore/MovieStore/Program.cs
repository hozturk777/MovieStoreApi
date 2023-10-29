using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieStore;
using MovieStore.DbOperations;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



// JWT


var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MovieContext>(options => options.UseInMemoryDatabase(databaseName :"MovieDB"));
builder.Services.AddDbContext<MovieContext>();
builder.Services.AddScoped<IMovieContext, MovieContext>();
//builder.Services.AddScoped<IMovieContext>(provider => provider.GetService<MovieContext>());
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




//  JWT


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManagers.Appsetting["Jwt:SecurityKey"])),
        ValidIssuer = ConfigurationManagers.Appsetting["Jwt:Issuer"],
        ValidAudience = ConfigurationManagers.Appsetting["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthentication();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiMovieStore", Version = "v1" });

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Please insert token",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.Http,
    //    BearerFormat = "JWT",
    //    Scheme = "bearer"
    //});
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] { }
    //    }

    //});
});





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

app.MapRazorPages();

// Authentication & Authorication
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
