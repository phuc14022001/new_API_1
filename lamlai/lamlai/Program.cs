using lamlai.data;
using lamlai.Models;
using lamlai.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<myDBcontext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Mydb"));
});
builder.Services.AddScoped<Iloai, LoaiRepository>();//để tạo repository liên kết giữa data vs API
builder.Services.AddScoped<IHangHoaReponsitory, HangHoaRepositormemor>();
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyByte = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //tự cấp Token
        ValidateIssuer = false,
        ValidateAudience = false, // nếu sủ dụng dịch vụ
         
        //ký vào token
        ValidateIssuerSigningKey=true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyByte),

        ClockSkew = TimeSpan.Zero
    };
});
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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
