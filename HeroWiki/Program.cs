using ServerWiki.EndPoints;
using ServerWiki.Shared.Data.DB;
using ServerWiki_Console;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ServerWikiContext>();
builder.Services.AddTransient<DAL<Server>>();
builder.Services.AddTransient<DAL<Server>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsServer();
app.AddEndPointsApplication();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
