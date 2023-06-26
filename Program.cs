using claimbased.Data;
using claimbased.Services;
using claimbased.PolicyProvider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<BankContext>(builder.Configuration.GetConnectionString("BankConnection"));


builder.Services.AddScoped<ClientServices>();
// builder.Services.AddScoped<AccountServices>();
// builder.Services.AddScoped<AccountTypeServices>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => 
        {
            options.TokenValidationParameters  = new TokenValidationParameters{
                
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        builder.Services.AddAuthorization(

            options => {
                options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminType", "1","2","3","4"));
            }
        );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
