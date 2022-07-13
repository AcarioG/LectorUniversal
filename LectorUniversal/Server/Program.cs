using Duende.IdentityServer.Services;
using LectorUniversal.Server.Data;
using LectorUniversal.Server.Helpers;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using LectorUniversal.Shared.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSecurityTokenHandler>(opt =>
{
    opt.InboundClaimTypeMap.Clear();
     
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LectorUniversal");
//var AzureStorageCS = builder.Configuration.GetConnectionString("AzureStorage");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddMvc().AddJsonOptions(op => 
    op.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(conf =>
{
    conf.CreateMap<Book, Book>().ForMember(x => x.Cover, opt => opt.Ignore());
    conf.CreateMap<Pages, Pages>().ForMember(x => x.ImageUrl, opt => opt.Ignore());
}, typeof(StartupBase));

builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddTransient<IProfileService, IdentityProfileService>();
//builder.Services.AddSingleton(new BlobServiceClient(builder.Configuration.GetConnectionString("AzureStorage")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//app.UseMiddleware<JwtSecurityTokenHandler>();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
