using Luftborn.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomRepository();
builder.Services.AddCustomServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowIonicApp",
        builder => builder
            .WithOrigins("http://localhost:8100")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowIonicApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddCustomMiddleware();

app.MapControllers();

app.Run();
