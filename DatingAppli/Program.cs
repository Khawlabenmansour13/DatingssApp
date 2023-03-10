using DatingApp.Application.Users.Handlers;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using DatingApp.Application.Users.Commands.CreateUser;
using AutoMapper;
using DatingApp.Application.Users.Common.Mapper;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using DatingApp.Infrastructure.Repositories.UserRepository.UserQuery;
using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Command;
using DatingApp.Infrastructure.Repositories.UserRepository.UserCommand;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//si valeur null mayraj3ouch .
builder.Services.AddControllers()
           .AddJsonOptions(opt =>
           {
               opt.JsonSerializerOptions.IgnoreNullValues = true;
           });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dataBase
builder.Services.AddDbContext<DataContexte>(opt =>
   opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnexionContext") ?? throw new InvalidOperationException("Connection string 'ConnexionContext' not found.")));
// Register dependencies
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton(sp =>
{
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new DatingApplicationMappingUser());


    });
    return mappingConfig.CreateMapper();
});


////Inject repository
////builder.Services.AddScoped(typeof(GetAllUsersHandlers));
//builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
//builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository<AppUser>>();
//builder.Services.AddScoped(typeof(ICommandRepository<AppUser>), typeof(CommandRepository<>));
//builder.Services.AddTransient<IUserCommandRepository, UserCommandRepository>();


////Inject Mediator 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddTransient<Mediator>();

builder.Services.AddMediatR(typeof(GetAllUsersHandlers).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetUserByIdHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetUserByEmailHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateUserHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteUserHandler).GetTypeInfo().Assembly);


builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<IUserQueryRepository, UserQueryRepository<AppUser>>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<IUserCommandRepository, UserCommandRepository>();


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
