using Microsoft.Extensions.FileProviders;
using TestAuto.Application;
using TestAuto.Infrastructure;
using TestAuto.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPostgreSQL(builder.Configuration["ConnectionStrings:PostgreSQL"]!);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12);
    options.Cookie.Name = ".Test.Session";
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomAuthenticationMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSession();
app.UseDefaultFiles(new DefaultFilesOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html"))
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html"))
});
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "admin", pattern: "{area:exist}/{controller}/{action}/{token}");
app.Run();
