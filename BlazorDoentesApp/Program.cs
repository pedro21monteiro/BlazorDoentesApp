using BlazorDoentesApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//services Doentes
builder.Services.AddSingleton <DoentesService>();
builder.Services.AddHttpClient<IDoenteService, DoentesService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5103/");
});
//services Consultas
builder.Services.AddSingleton<ConsultasService>();
builder.Services.AddHttpClient<IConsultasService, ConsultasService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5103/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
