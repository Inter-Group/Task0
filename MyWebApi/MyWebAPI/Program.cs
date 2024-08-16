using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cho phép tất cả mọi người sử dụng API của mình
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
                            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Tạo csdl
builder.Services.AddDbContext<ProductsConText>(option => 
                            option.UseSqlServer(builder.Configuration.GetConnectionString("cnn")));

//Đăng kí để sử dụng mapper
builder.Services.AddAutoMapper(typeof(Program));

//Đăng kí để sử dụng repositories
//AddScoped dùng để giữ các dịch vụ gắn liền với một request(ví dụ các dịch vụ cần dùng đến csdl).
builder.Services.AddScoped<IRepository, ProductsRepository>();

//AddTransient phù hợp với các dịch vụ nhẹ và không lưu trữ trạng thái(ví dụ các dịch vụ tính toán, không lưu trữ dữ liệu)
//services.AddTransient<IBookRepository, BookRepository>();

//AddSingleton dùng để duy trì trạng thái hoặc dùng chung dữ liệu cho tất cả các request và các thread trong suốt thời gian chạy của ứng dụng.(ví dụ như bộ nhớ đệm)
//services.AddSingleton<IMyService, MyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
