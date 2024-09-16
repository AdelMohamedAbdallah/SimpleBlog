using Microsoft.EntityFrameworkCore;
using SimpleBlog.BLL.Mapper;
using SimpleBlog.BLL.Repository;
using SimpleBlog.BLL.Services;
using SimpleBlog.DAL.ConnectionData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
	opt.UseSqlServer(connection);
});

builder.Services.AddAutoMapper(mapper => mapper.AddProfile(new DomainProfile()));

builder.Services.AddScoped<IBlogRepo, BlogRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
