using WebStoreApi.Filters;
using WebStoreApi.Middlewares;
using WebStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<StatsMiddleware>();

/*
app.Use((context, Next) =>
{

    DateTime requestTime = DateTime.Now;

    var result = Next(context);

    DateTime responseTime = DateTime.Now;
    TimeSpan processDuration = responseTime - requestTime;
    Console.WriteLine("[Inline Middleware} Process Duration=" + processDuration.TotalMilliseconds + "ms");

    return result;
});
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
