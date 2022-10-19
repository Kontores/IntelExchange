using IntelExchange.Database.Repositories;
using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataAccess.Services;
using IntelExchange.DataModels;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "defaultPolicy",
                      policy =>
                      {
                          policy
                          .WithOrigins("http://localhost:3000", "https://localhost:3000")
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.LoginPath = new PathString("/account/login");
    options.LogoutPath = new PathString("/account/logout");
    options.Cookie.HttpOnly = false;
    options.Cookie.SameSite = SameSiteMode.None;
});
builder.Services.AddAuthorization();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserMockRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("defaultPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UsePathBase("/api");
app.MapControllers();

app.Run();
