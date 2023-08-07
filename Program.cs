using API;
using ApplicationCore;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Dependencies.ConfigureServices(builder.Configuration, builder.Services);
builder.Services.AddScoped(typeof(IAlunoService), typeof(AlunoService));
builder.Services.AddScoped(typeof(IAulaService), typeof(AulaService));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FilterException>();
})
                .AddXmlSerializerFormatters();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
