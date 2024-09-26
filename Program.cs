using FastemsBerget.Services;

namespace FastemsBerget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register HttpClient for making API calls
            builder.Services.AddHttpClient();

            // Register the WorkOrderService
            builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers(); // Map the controllers

            app.Run();
        }
    }
}
