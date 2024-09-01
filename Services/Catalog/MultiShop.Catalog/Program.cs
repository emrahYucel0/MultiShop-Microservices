using MultiShop.Catalog.Extentions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// JWT kimlik doðrulamasýný yapýlandýr
builder.Services.AddJwtAuthentication(builder.Configuration);

// Hizmetleri kaydet
builder.Services.AddServices();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Veritabaný ayarlarýný yapýlandýr ve kaydet
builder.Services.ConfigureDatabaseSettings(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
