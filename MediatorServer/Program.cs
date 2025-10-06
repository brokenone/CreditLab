
using MediatorServer.Services;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Logging;

namespace MediatorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton(new ServerPaymentService(1000m)); // Adding Start Balance
            builder.Services.AddScoped<IMediatorService, MediatorService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();

            builder.Services.AddHttpClient("CreditDataHub", c => c.BaseAddress = new Uri("https://localhost:7189"));
            builder.Services.AddHttpClient("FiscoEmulator", c => c.BaseAddress = new Uri("https://localhost:7244"));
            builder.Services.AddHttpClient("BankingEmulator", c => c.BaseAddress = new Uri("https://localhost:7182"));

            builder.Services.AddAppLogger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mediator API V1");
                    c.RoutePrefix = string.Empty;
                });
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
