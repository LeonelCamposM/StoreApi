using Google.Api;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
}

app.UseHttpsRedirection();
app.UseCors("BlazorCors");
app.UseAuthorization();

app.MapControllers();

app.Run();

