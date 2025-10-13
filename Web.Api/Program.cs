using Application;
using Infrastructure;
using Scalar.AspNetCore;
using Serilog;
using Web.Api;
using Web.Api.Extensions;
using Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddPresentation()
    .AddApplication(builder.Configuration,builder.Host)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Scalar Example";
        opt.Theme = ScalarTheme.Mars;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.UseRequestContextLogging();

app.UseHttpsRedirection();

app.UseCors("Default");

app.UseAuthorization();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
