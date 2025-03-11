using domain;
using Microsoft.EntityFrameworkCore;
using model.DbContext;
using model.Entities;
using MudBlazor.Services;
using webapp.Components;
using webapp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<FiscusDbContext>(options => options.UseSqlite($"Data Source=/app/data/fiscus.sqlite"));
builder.Services.AddScoped<IRepository<Invoice>,InvoiceRepository>();
builder.Services.AddScoped<IInvoiceRepository,InvoiceRepository>();
builder.Services.AddScoped<IRepository<Recipient>,RecipientRepository>();
builder.Services.AddScoped<IRepository<Organisation>,OrganisationRepository>();
builder.Services.AddScoped<AppState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Create Db
var dbPath = "/app/data";
if (!Directory.Exists(dbPath))
{
    Directory.CreateDirectory(dbPath);
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FiscusDbContext>();
    dbContext.Database.Migrate(); // Führt Migrationen aus oder erstellt die DB
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();