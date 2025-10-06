
using CreditDataHub.API.Data;
using CreditDataHub.API.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Logging;

namespace CreditDataHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

            builder.Services.AddDbContext<CreditDataContext>(options => 
                options.UseNpgsql(connectionString));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();

            builder.Services.AddAppLogger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
