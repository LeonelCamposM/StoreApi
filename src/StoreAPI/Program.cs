using Google.Api;
using Google.Cloud.Firestore;
using GrpcService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddGrpcClient<Products.ProductsClient>(
    o => o.Address = new Uri("https://localhost:7138"));

// Firebase DB Singletone
string path = "key.json";
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
builder.Services.AddSingleton(provider =>
{
    string projectId = "storedb-84cea";
    return FirestoreDb.Create(projectId);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorCors", builder =>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

builder.Logging
.ClearProviders()
.AddSimpleConsole(options => {
    options.SingleLine = true;
    options.TimestampFormat = "HH:mm:ss ";
    options.UseUtcTimestamp = true;
})
.AddDebug()
.AddApplicationInsights(
telemetry =>
telemetry.ConnectionString =
builder.Configuration["Azure:ApplicationInsights:ConnectionString"],
loggerOptions => { });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
        app.UseDeveloperExceptionPage();
    else
        app.UseExceptionHandler("/error");

}

app.MapGet("/error",
[EnableCors("AnyOrigin")]
[ResponseCache(NoStore = true)] (HttpContext context) =>
{
    var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
    var details = new ProblemDetails();
    details.Detail = exceptionHandler?.Error.Message;
    details.Extensions["traceId"] = System.Diagnostics.Activity.Current?.Id ?? context.TraceIdentifier;
    details.Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
    details.Status = StatusCodes.Status500InternalServerError;

    // Check if the status code is 404
    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        details.Title = "Resource not found";
        details.Status = StatusCodes.Status404NotFound;
    }


    context.Response.StatusCode = details.Status.Value;

    return Results.Json(details);
});


app.UseHttpsRedirection();
app.UseCors("BlazorCors");
app.UseAuthorization();

app.MapControllers();

app.Run();

