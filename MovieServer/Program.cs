using Microsoft.EntityFrameworkCore;
using MovieServer.Data.DAO;
using MovieServer.Core.Services.csvServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MainConnectionString"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                     // Number of retry attempts
            maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
            errorNumbersToAdd: null                 // Specify SQL error numbers if needed
        )
    )
);

//builder.Services.AddScoped<IGPTservices, GPTservices>();
builder.Services.AddScoped<ICSVService, AddData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
