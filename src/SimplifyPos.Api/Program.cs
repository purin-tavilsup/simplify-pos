using SimplifyPos.Application.Extensions.DependencyInjection;
using SimplifyPos.Infrastructure.Extensions.DependencyInjection;

namespace SimplifyPos.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddApplication();
			builder.Services.AddInfrastructure();
			builder.Services.AddControllers();
			
            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
