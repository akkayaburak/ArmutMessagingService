using Business;
using Contracts.Entity;
using Contracts.Interface;
using Contracts.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void RegisterConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMessageService, MessageService>();

            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSignalR();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddScoped<IValidator<RegisterCommand>, UserRegisterValidator>();
            builder.Services.AddScoped<IValidator<LoginCommand>, UserLoginValidator>();

        }
    }
}