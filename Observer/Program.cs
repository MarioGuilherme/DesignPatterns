using Observer.Application.Observers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDealsObserver, MarketingCampaignObserver>();
builder.Services.AddSingleton<IDealsObserver, WebsiteCatalogObserver>();
builder.Services.AddSingleton<IDealsSubject, DealsSubject>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
