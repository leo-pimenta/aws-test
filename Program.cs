using aws_test.Database;
using aws_test.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(kestrel => 
{
    kestrel.ListenAnyIP(80);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CadastroContext>();
new DependencyInjectionConfigurator(builder.Services).Configure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();