var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Error Handling Middleware
app.UseExceptionHandler(a =>
{
    a.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Internal Server Error");
    });
});

// Authentication Middleware (simple)
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("AuthToken"))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }
    await next();
});

// Logging Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

app.Run();
