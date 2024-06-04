using tbb.events.api.Controllers;
using tbb.events.api.Interfaces;
using tbb.events.api.Providers;
using tbb.events.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventProvider, EventProvider>();
builder.Services.AddScoped<IEventsController, EventsController>();

builder.Services.AddControllers();
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
