using IntelExchange.Database.Repositories;
using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataAccess.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using IntelExchange.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(Configuration.ConfigureCors);
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(Configuration.ConfigureCookies);
builder.Services.AddAuthorization(Configuration.ConfigureAuthorization);
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserMockRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddValidation();


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
