using DatingApp.Application.Users.Handlers;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

using AutoMapper;

using System.Reflection;
using Microsoft.AspNetCore.Hosting;

using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Command;
using DatingApp.Application.Persons.Common.Mapper;
using DatingApp.Application.Persons.Handlers;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonCommand;
using DatingsApp.Interfaces;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Referral System API",
        Description = "An ASP.NET Core Web API for managing Referral System",
        TermsOfService = new Uri("https://example.com/terms"),
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//dataBase
builder.Services.AddDbContext<DataContexte>(opt =>
   opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnexionContext") ?? throw new InvalidOperationException("Connection string 'ConnexionContext' not found.")));
// Register dependencies
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton(sp =>
{
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new DatingApplicationMappingPerson());


    });
    return mappingConfig.CreateMapper();
});
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding
                  .UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };

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

builder.Services.AddMediatR(typeof(GetAllPersonsHandlers).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetPersonByIdHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetPersonByEmailHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreatePersonHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdatePersonHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeletePersonHandler).GetTypeInfo().Assembly);


builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<IPersonQueryRepository, PersonQueryRepository<Person>>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<IPersonCommandRepository, PersonCommandRepository>();


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
