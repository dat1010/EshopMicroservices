var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    if (context.HostingEnvironment.IsDevelopment())
    {
        config.AddJsonFile("Properties/launchSettings.json", optional: true);
    }
});
// Add services to the container.

var app = builder.Build();

// Configure the http pipeline.


var urls = builder.Configuration["profiles:https:applicationUrl"]?.Split(';');
if (urls != null)
{
    foreach (var url in urls)
    {
        app.Urls.Add(url);
    }
}


app.Run();
