using System.Reflection;
using Serilog;

namespace aws_test.Startup
{
    public class LogConfigurator : IConfigurator
    {
        private readonly IServiceCollection Services;

        public LogConfigurator(IServiceCollection services)
        {
            this.Services = services;
        }

        public void Configure()
        {
            string logPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "log");
            
            Serilog.ILogger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logPath)
                .CreateLogger();
            
            Services.AddSingleton<Serilog.ILogger>(log);
        }
    }
}