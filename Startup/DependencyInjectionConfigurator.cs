using AutoMapper;
using aws_test.Domain;
using aws_test.Dto;
using aws_test.Service;

namespace aws_test.Startup
{
    public class DependencyInjectionConfigurator : IConfigurator
    {
        private readonly IServiceCollection Services;

        public DependencyInjectionConfigurator(IServiceCollection services)
        {
            this.Services = services;
        }

        public void Configure()
        {
            ConfigureMapper();
            Services.AddScoped<ICadastro, CadastroService>();
        }

        private void ConfigureMapper()
        {
            Services.AddSingleton<IMapper>(provider => 
            {
                var configuration = new MapperConfiguration(configuration => 
                {
                    configuration.CreateMap<Cadastro, CadastroDto>().ReverseMap();
                });

                return configuration.CreateMapper();
            });
        }
    }
}