using Microsoft.EntityFrameworkCore;
using SimpleBlog.BLL.Mapper;
using SimpleBlog.BLL.Repository;
using SimpleBlog.BLL.Services;
using SimpleBlog.DAL.ConnectionData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

builder.Services.AddAutoMapper(mapper => mapper.AddProfile(new DomainProfile()));

builder.Services.AddScoped<IBlogRepo, BlogRepo>();

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
