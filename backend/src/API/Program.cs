using API.Common.Extensions;
using API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddIdentityServices();
    builder.Services.AddEndpoints();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // configure database connection
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<LostDocumentsContext>(x =>
    {
        x.UseSqlite(connectionString);
    });

    // configure cors
    builder.Services.AddCors(o =>
   {
       o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
   });
}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.Run();

