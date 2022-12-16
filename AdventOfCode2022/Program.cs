using AdventOfCode2022.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<One>();
builder.Services.AddTransient<Two>();
builder.Services.AddTransient<Three>();
builder.Services.AddTransient<Four>();
builder.Services.AddTransient<Five>();
builder.Services.AddTransient<Six>();

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

app.MapGet("/daytwo/two", (Two two) =>
{
    return two.CalculateScorePartTwo();
}).WithTags("Day two");

app.MapGet("/daythree/one", (Three three) => {
    return three.GetBackpacksTotalScore();
}).WithTags("Day three");

app.MapGet("/daythree/two", (Three three) =>
{
    return three.GetElfPackTotalScore();
}).WithTags("Day three");

app.MapGet("/dayfour/one", (Four four) =>
{
    return four.GetFullyOverlappingElfCount();
}).WithTags("Day four");

app.MapGet("/dayfour/two", (Four four) =>
{
    return four.GetOverlappingElfCount();
}).WithTags("Day four");

app.MapGet("/dayfive/one", (Five five) =>
{
    return five.GetCargoLettersAfterFullMove();
}).WithTags("Day five");

app.MapGet("/dayfive/two", (Five five) =>
{
    return five.GetCargoLetters9001();
}).WithTags("Day five");

app.MapGet("/daysix/one/{amount}", (int amount, Six six) =>
{
    return six.GetFirstMarker(amount);
}).WithTags("Day six");

app.Run();