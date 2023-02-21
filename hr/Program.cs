using hr.AutoMapper;
using hr.DB;
using hr.Services;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opt => {
	opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
	opt.EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<ICandidateService, CandidateService>();
builder.Services.AddTransient<IPlaceOfWorkService, PlaceOfWorkService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();
builder.Services.AddTransient<ITechnologyService, TechnologyService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
