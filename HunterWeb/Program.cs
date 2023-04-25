

using BLL.Configarations;
using HunterWeb.Mappings;

var builder = WebApplication.CreateBuilder(args);

var configure = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllersWithViews();

//builder.Services.AddConfigureBLL(connectionString);

builder.Services.AddConfigureBLL(builder.Configuration);
builder.Services.AddAutoMapper(typeof(ShortAnimalViewModelProfile), typeof(AnimalViewModelProfile), typeof(HuntingSeasoViewModelProfile)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Animal}/{action=Index}/{id?}");

app.Run();
