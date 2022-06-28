using Microsoft.EntityFrameworkCore;
using Notices.Core.Services;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.Notices.db",
        sqlOptions => sqlOptions.MigrationsAssembly("Notices.Infrastructure")
    )
);

builder.Services.AddScoped<INoticeRepository, NoticeRepository>();
builder.Services.AddScoped<INoticeService, NoticeService>();

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