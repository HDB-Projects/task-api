using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Services;
using Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMessageBus, FakeMessageBus>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

builder.Services.AddControllers();

builder.Services.AddScoped<TaskService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
