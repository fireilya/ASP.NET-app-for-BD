using Dao.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddDao()
   .AddSwaggerGen()
   .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();