using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/ahmadovbekzod94_gmail_com", (string? x, string? y) =>
{
    if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
    {
        return Results.Text("NaN", "text/plain");
    }

    if (!BigInteger.TryParse(x, out BigInteger numX) || !BigInteger.TryParse(y, out BigInteger numY))
    {
        return Results.Text("NaN", "text/plain");
    }

    if (numX < 0 || numY < 0)
    {
        return Results.Text("NaN", "text/plain");
    }

    BigInteger result = CalculateLCM(numX, numY);

    return Results.Text(result.ToString(), "text/plain");
});

app.MapGet("/health", () => Results.Text("OK", "text/plain"));

static BigInteger CalculateGCD(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        BigInteger temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

static BigInteger CalculateLCM(BigInteger x, BigInteger y)
{
    if (x == 0 || y == 0) return 0;
    return BigInteger.Abs(x / CalculateGCD(x, y) * y);
}

await app.RunAsync();
