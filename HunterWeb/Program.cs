

using BLL.Configarations;
using HunterWeb.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddConfigureBLL(connectionString);

builder.Services.AddConfigureBLL();
builder.Services.AddAutoMapper(typeof(ShortAnimalViewModelProfile), typeof(AnimalViewModelProfile), typeof(HuntingSeasoViewModelProfile),
    typeof(InfoAnimalViewModelProfile), typeof(InfoHuntingSeasonViewModelProfile));

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
