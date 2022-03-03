using aws_test.Database;
using aws_test.Error;
using aws_test.Startup;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(kestrel => 
{
    kestrel.ListenAnyIP(80);
});

// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers(options => new DtoValidationConfigurator(options).Configure());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CadastroContext>();

new List<IConfigurator>()
{
    new DependencyInjectionConfigurator(builder.Services),
    new LogConfigurator(builder.Services)
}.ForEach(config => config.Configure());

var app = builder.Build();

var log = app.Services.GetService<Serilog.ILogger>();
log?.Information($"Environment: {app.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<GlobalErrorHandler>();
app.MapControllers();
app.Run();