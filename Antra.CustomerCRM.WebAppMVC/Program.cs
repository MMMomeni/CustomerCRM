using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Infrastructure.Data;
using CustomerCRM.Infrastructure.Repository;
using CustomerCRM.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Basically this line will create a new instance of CustomerCrmDbContext
builder.Services.AddSqlServer <CustomerCrmDbContext>(builder.Configuration.GetConnectionString("CustomerCRM"));
//another way is :
/*
builder.Services.AddDbContext<CustomerCrmDbContext>(
    option => {
        option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerCRM"));
    }
    );
*/

/*This means that whenever we want to create an object of IRegionRepositoryAsync, an object of RegionRepositoryAsync 
 * will be created and passed to it. (upcasting because we cannot make an object of an Interface)
 * Whenever we use an object of RegionRepositoryAsync it is actualy an object of IRegionRepositoryAsync,
 * but how ?
 * because RegionRepositoryAsync has been upcasted to IRegionRepositoryAsync.
*/ //Repository injection
builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();

//Service injection
//We need this for the controller class RegionController
builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();


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
