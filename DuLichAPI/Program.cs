using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DAL.Helper.Interfaces;
using DAL.Helper;
using CodeMegaVNPay.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IDatabase, Database>();
builder.Services.AddTransient<ITourDAL, TourDAL>();
builder.Services.AddTransient<ITourBLL, TourBLL>();
builder.Services.AddTransient<IUudaiDAL, UudaiDAL>();
builder.Services.AddTransient<IUudaiBLL, UudaiBLL>();
builder.Services.AddTransient<IDiadiemDAL, DiaDiemDAL>();
builder.Services.AddTransient<IDiadiemBLL,DiadiemBLL >();
builder.Services.AddTransient<IUserDAL, UserDAL>();
builder.Services.AddTransient<IUserBLL, UserBLL>();
builder.Services.AddTransient<IOrderDAL, OrderDAL>();
builder.Services.AddTransient<IOrderBLL, OrderBLL>();
builder.Services.AddTransient<INguoidungDAL, NguoidungDAL>();
builder.Services.AddTransient<INguoidungBLL, NguoidungBLL>();
builder.Services.AddTransient<ITourDetailDAL, TourDetailDAL>();
builder.Services.AddTransient<ITourDetailBLL, TourDetailBLL>();
builder.Services.AddTransient<ILichtrinhDAL, LichtrinhDAL>();
builder.Services.AddTransient<ILichtrinhBLL, LichtrinhBLL>();
builder.Services.AddTransient<IThongkeDAL, ThongkeDAL>();
builder.Services.AddTransient<IThongkeBLL, ThongkeBLL>();
builder.Services.AddTransient<IVnPayService, VnPayService>();
builder.Services.AddEndpointsApiExplorer();
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
//var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
 //       IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
