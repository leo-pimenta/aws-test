using Microsoft.AspNetCore.Mvc;

namespace aws_test.Startup
{
    public class DtoValidationConfigurator : IConfigurator
    {
        private readonly MvcOptions Options;

        public DtoValidationConfigurator(MvcOptions options)
        {
            this.Options = options;
        }

        public void Configure()
        {
            Options.Filters.Add(typeof(CustomActionFilterAttribute));
        }
    }
}