
using Agenda.Application.Interfaces;
using Agenda.Application.Mappings;
using Agenda.Application.Services;
using Agenda.Infra.Data.Repositories;
using Agenda.Infra.Ioc;
using Serilog;

namespace Agenda.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddInfraestructure(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configurar o Serilog
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();


            // Usar Serilog como provedor de logging
            builder.Host.UseSerilog();


            //Serviços
            builder.Services.AddScoped<IContatoService, ContatoService>();
            builder.Services.AddScoped<ITelefoneService, TelefoneService>();

            //Repositórios
            builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

            //Perfis de mapeamento
            builder.Services.AddAutoMapper(typeof(EntityToDtoMapping));

            //cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
