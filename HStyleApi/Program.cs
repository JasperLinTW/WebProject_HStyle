using HStyleApi.Controllers;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//在ConfigureServices方法中添加这个NewtonsoftJson方法引用
builder.Services.AddControllers().AddNewtonsoftJson(option =>
//忽略循环引用
option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var HstoreconnectString = builder.Configuration.GetConnectionString("HstyleStore");
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(HstoreconnectString));

//var HstoreconnectString = builder.Configuration.GetConnectionString("HstyleStore");
//builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(HstoreconnectString));


builder.Services.AddSingleton<WebSocketController>();

string MyAllowOrigins = "AllowAny";
builder.Services.AddCors(options => {
	options.AddPolicy(
			name: MyAllowOrigins,
			policy => policy.WithOrigins("*")
			.WithHeaders("*")
			.WithMethods("*"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    //未登入時會自動導到這個網址
    //option.LoginPath = new PathString("/api/Member/NoLogin"); //先改成null
});

var app = builder.Build();
app.UseCors(MyAllowOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets(new WebSocketOptions
{
	KeepAliveInterval = TimeSpan.FromSeconds(60),
});

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


