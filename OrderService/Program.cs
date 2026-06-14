var builder = WebApplication.CreateBuilder(args);

// Enregistrement des services dans le container DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// appsettings variables
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var kafkaServers = builder.Configuration["Kafka:BootstrapServers"];


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // on branche les controllers à la pipeline

app.Run();