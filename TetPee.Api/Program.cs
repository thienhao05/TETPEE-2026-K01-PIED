using Microsoft.EntityFrameworkCore;
using TetPee.Api.Middlewares;
using TetPee.Repository;
using UserService = TetPee.Service.User;
using CategoryService = TetPee.Service.Category;
using SellerService = TetPee.Service.Seller;
using IdentityService = TetPee.Service.Identity;

/*
 * tại vì sao mà mình phải dùng cái này ?
 * Nếu như mình đề IService với Service
 * Bị trùng nhiều quá chấm nhiều xấu
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//kết nối xuống database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


//khai báo cho tối ưu hơn
builder.Services.AddScoped<UserService.IService, UserService.Service>();
builder.Services.AddScoped<CategoryService.IService, CategoryService.Service>();
builder.Services.AddScoped<SellerService.IService, SellerService.Service>();
builder.Services.AddScoped<IdentityService.IService, IdentityService.Service>();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();

//trên khai báo dịch vụ mình xài

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();