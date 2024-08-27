using Data.Contexts;
using Data.Repositories;
using Domain.IRepositories;
using Domain.IServices;
using FlashCardAPI.RepoData.Repository;
using FlashCardAPI.ServiceData.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection"))
    );

//Transient Classes

builder.Services.AddTransient<IUserRepository, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IDeckRepository, DeckRepo>();
builder.Services.AddTransient<IDeckService, DeckService>();

builder.Services.AddTransient<IFlashcardRepository, FlashcardRepo>();
builder.Services.AddTransient<IFlashcardService, FlashcardService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//app.UseMiddleware<MiddlewareException>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
