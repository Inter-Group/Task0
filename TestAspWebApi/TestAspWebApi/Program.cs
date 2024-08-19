using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.Repository;
using Core.Services;
using Infrastructure.Database;
using Infrastructure.Respository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICategogyRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ITaskService, TaskServices>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// ??ng ký d?ch v? cho DonHang
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>(); // ??m b?o DonHangRepository tri?n khai IDonHangRepository
builder.Services.AddScoped<IDonHangServices, DonHangServices>(); // ??m b?o DonHangServices tri?n khai IDonHangServices
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("TestAspWebApi"));
});

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
