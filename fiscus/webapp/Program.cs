using domain;
using Microsoft.EntityFrameworkCore;
using model.DbContext;
using model.Entities;
using MudBlazor.Services;
using webapp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<FiscusDbContext>(options => options.UseSqlite($"Data Source=Database/fiscus.sqlite"));
builder.Services.AddScoped<IRepository<Invoice>,InvoiceRepository>();
builder.Services.AddScoped<IRepository<Recipient>,RecipientRepository>();
builder.Services.AddScoped<IRepository<Organisation>,OrganisationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();