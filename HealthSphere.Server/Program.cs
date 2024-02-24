using HealthSphere.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure HttpClient for AuthServiceClient
builder.Services.AddHttpClient("AuthServiceClient", client =>
{
    client.BaseAddress = new Uri(Helpers.GetServiceEndpoint(Helpers.Services.Authentication));
    // Configure timeouts, headers, etc. as needed
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Serve static files and enable default file mapping
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseMiddleware<AuthenticationMiddleware>();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
