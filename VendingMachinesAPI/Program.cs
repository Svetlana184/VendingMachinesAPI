using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendingMachinesAPI;
using VendingMachinesAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder();
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<VendingMachinesContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader());
});
builder.Services.AddRateLimiter(opts =>
{
    opts.AddFixedWindowLimiter("fixedWindow", fixOpts =>
    {
        fixOpts.PermitLimit = 1;
        fixOpts.QueueLimit = 0;
        fixOpts.Window = TimeSpan.FromSeconds(15);
    });
});
builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts => {
    opts.SerializerSettings.NullValueHandling
    = Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.AddAuthentication();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidateIssuer = true,
           
            ValidIssuer = AuthOptions.ISSUER,
           
            ValidateAudience = true,
           
            ValidAudience = AuthOptions.AUDIENCE,
           
            ValidateLifetime = true,
           
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
          
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

    response.ContentType = "text/plain; charset=UTF-8";
    string mes = "";
    switch (response.StatusCode)
    {
        case 400:
            {
                mes = "íåïðàâèëüíî ñôîðìèðîâàí çàïðîñ";
                break;
            }
        case 401:
            {
                mes = "âû íå àâòîðèçîâàíû";
                break;
            }
        case 403:
            {
                mes = "íåïðàâèëüíûå àâòîðèçàöèîííûå äàííûå";
                break;
            }
        case 404:
            {
                mes = path + " íå íàéäåí";
                break;
            }

    }
    My_errors newError = new My_errors()
    {
        Timestamp = DateTime.Now.Ticks,
        Message = mes,
        ErrorCode = response.StatusCode + 1000
    };
    await response.WriteAsJsonAsync(newError);
});
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.UseCors("CorsPolicy");

app.MapGet("/", () => "Hello World!");
app.Map("/login/api/v1/SignIn", async (User emp, VendingMachinesContext db) =>
{
    User? employee = await db.Users.FirstOrDefaultAsync(p => p.Login == emp.Login && p.Password == emp.Password);
    if (employee is null)
    {
        My_errors newError = new My_errors()
        {
            Timestamp = DateTime.Now.Ticks,
            Message = "íåïðàâèëüíûå àâòîðèçàöèîííûå äàííûå",
            ErrorCode = 1401
        };
        return Results.Json(newError);
    }
    var claims = new List<Claim> { new Claim(ClaimTypes.Surname, emp.Password) };
    // ñîçäàåì JWT-òîêåí
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
    audience: AuthOptions.AUDIENCE,
    claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
    var response = new
    {
        access_token = encoderJWT,
        login = emp.Login
    };
    return Results.Json(response);
});


app.Run();
public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // èçäàòåëü òîêåíà
    public const string AUDIENCE = "MyAuthClient"; // ïîòðåáèòåëü òîêåíà
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // êëþ÷ äëÿ øèôðàöèè
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}