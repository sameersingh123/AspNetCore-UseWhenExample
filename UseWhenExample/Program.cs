var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseWhen(context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context,next) =>
        {
            await context.Response.WriteAsync("Hello from middleware branch");
            await next(context);
        });
    });

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from main branch");
});

app.Run();
