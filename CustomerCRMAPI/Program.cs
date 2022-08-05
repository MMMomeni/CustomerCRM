using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Entities;
using CustomerCRM.Infrastructure.Data;
using CustomerCRM.Infrastructure.Repository;
using CustomerCRM.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlServer<CustomerCrmDbContext>(builder.Configuration.GetConnectionString("CustomerCRM"));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CustomerCrmDbContext>()
    .AddDefaultTokenProviders();

/* AddDefaultPolicy(): different policies (like specifying which URL can access it (Get, Post, etc))
 *      AllowAnyHeader(): any header
 *      AllowAnyMethod(): Get, Put, etx
 *      AllowAnyOrigin(): all origins including both schemes http and https.
 *      WithOrigins(): specify certain origins.
 */
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepositoryAsync>();


builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IAccountServiceAsync, AccountServiceAsync>();

/*These lines sets up the authentication process and configures the options
  also uses token info appsetting (JWT)*/
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{ //Should the token be saved after creation ?
    options.SaveToken = true;
    //for now false
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        // Reading Audience from appsetting
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        // Reading Issuer from appsetting
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        // Setting the Secret from appsetting and encoding it
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
// For login and log off
app.UseAuthentication();
app.UseAuthorization();

// Map http requests with the controllers
app.MapControllers();

app.Run();
