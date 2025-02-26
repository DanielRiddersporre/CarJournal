using be_api.Mappers;
using be_api.Services;
using be_data.Mappers;
using be_data.contexts;
using be_data.repositories;
using be_domain.Interfaces.Repositories;
using be_domain.Interfaces.Services;
using be_domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


// Register the DbContext
builder.Services.AddDbContext<CarJournalContext>(options =>
    options.UseSqlServer(
        "Server=127.17.0.2,1433;Database=CarJournal;User=SA;Password=MniDR1986!;Encrypt=True;TrustServerCertificate=True;"));

// Register Mappers with the DI container
builder.Services.AddScoped<JournalEntryApiMapper>(); // API
builder.Services.AddScoped<JournalEntryDataMapper>(); // DATA

// Register Services with the DI container
builder.Services.AddScoped<IJournalEntryApiService, JournalEntryApiService>();
builder.Services.AddScoped<JournalEntryDomainService>();

// Register Repositories with the DI container
builder.Services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();