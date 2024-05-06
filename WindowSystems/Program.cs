using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_ChatGPT;

var builder = WebApplication.CreateBuilder(args);

//************************* For Chat GPT *************************************************************
builder.Services.AddHttpClient(); // Adds the IHttpClientFactory and related services to service coll

builder.Services.AddScoped<IChatCompletionService, ChatCompletionService>();
//************************* For Chat GPT *************************************************************

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
