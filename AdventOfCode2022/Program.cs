using AdventOfCode2022.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<One>();
builder.Services.AddTransient<Two>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/dayone/one", (One one) =>
{
    return one.CalculateTopOneElf();

}).WithTags("Day one");

app.MapGet("/dayone/two", (One one) =>
{
    return one.CalculateTopThreeElves();
}).WithTags("Day one");

app.MapGet("/daytwo/one", (Two two) =>
{
    return two.CalculateRockPaperScissorsScore();
}).WithTags("Day two");

app.Run();