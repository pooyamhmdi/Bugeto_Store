using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Carts;
using Bugeto_Store.Application.Services.Common.Queries.GetCategory;
using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.Common.Queries.GetMenuItem;
using Bugeto_Store.Application.Services.Common.Queries.GetSliders;
using Bugeto_Store.Application.Services.HomePages.Commands.AddHomePageImages;
using Bugeto_Store.Application.Services.HomePages.FacadPattern;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Bugeto_Store.Application.Services.Products.FacadPattern;
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Bugeto_Store.Application.Services.Users.Commands.LoginUser;
using Bugeto_Store.Application.Services.Users.Commands.RegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.UserStatusChange;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Bugeto_Store.Application.Services.Users.Queries.GetUsers;
using Bugeto_Store.Presistence.Contexts;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});
// اضافه کردن DbContext به DI container
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IUserStatusChangeService ,UserStatuChangeService>();
builder.Services.AddScoped<IRemoveUserService , RemoveUserService>();
builder.Services.AddScoped<IEditUsersSevice , EditUsersSevice>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IRemoveCategoryService, RemoveCategoryService>();
//facad inject
builder.Services.AddScoped<IProductFacad, ProductFacad>();
//menu & search
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();

//homepages sliders
builder.Services.AddScoped<ISlidersFacad, SlidersFacad>();

//homepages images
builder.Services.AddScoped<IHomePageImagesFacad, HomePageImagesFacad>();
//cart
builder.Services.AddScoped<ICartService , CartService>();  
// cookie
builder.Services.AddScoped<CookiesManeger>();   





var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
