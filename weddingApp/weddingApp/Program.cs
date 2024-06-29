using System.Text.Json.Serialization;
using weddingApp.Data;
using weddingApp.Services;
using Microsoft.EntityFrameworkCore;
using weddingApp.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IThingService, ThingService>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IUserService, UserServise>();
builder.Services.AddScoped<ICoupleService, CoupleService>();
builder.Services.AddScoped<IWeddingEventService, WeddingEventService>();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WeddingAppContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("WeddingDB"))
    );
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddAutoMapper(typeof(WeddingMappingProfile));

var allowSpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});
var app = builder.Build();
app.UseCors(allowSpecificOrigins);

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
