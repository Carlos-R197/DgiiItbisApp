using Api.Data;
using Api.Repositories.Contracts;
using Api.Repositories;
using Serilog;
using Serilog.Events;

string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Setup serilgo
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApiDbContext>();
builder.Services.AddScoped<IContributorRepository, ContributorRepository>();
builder.Services.AddScoped<ITaxReceiptRepository, TaxReceiptRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
{
    options.AddPolicy(
        name: myAllowSpecificOrigins, 
        policy => 
        {
            policy.WithOrigins("http://127.0.0.1:5173");
            policy.AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();
