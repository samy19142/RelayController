using Relay_controller_app.Interfaces;
using Relay_controller_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register Services Arduino
builder.Services.AddSingleton<IArduinoCommunicationService, ArduinoCommunicationService>();
builder.Services.AddScoped<IRelayService,RelayService>();
builder.Services.AddSingleton<ISerialPortService, SerialPortService>();

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
