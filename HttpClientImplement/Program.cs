using HttpClientImplement.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<HttpClientInterceptor>();


builder.Services.AddHttpClient<IHttpCientService, HttpCientService>(option =>
{
    option.BaseAddress = new Uri("https://localhost:7281/");
}).AddHttpMessageHandler<HttpClientInterceptor>();

//or
//builder.Services.AddHttpClient<IHttpCientService, HttpCientService>(option =>
//{
//    option.BaseAddress = new Uri("https://localhost:7281/");
//}).ConfigureHttpMessageHandlerBuilder(p =>
//{

//    p.PrimaryHandler = new HttpClientInterceptor();
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
