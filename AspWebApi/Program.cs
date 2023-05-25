using AspWebApi.Middlewares;
using BLL.Configarations;

var builder = WebApplication.CreateBuilder(args);

var configure = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfigureBLL(builder.Configuration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
