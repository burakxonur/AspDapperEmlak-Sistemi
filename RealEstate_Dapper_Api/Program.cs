using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StaticsRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StaticsRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.CharRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IStaticRepository, StaticRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocation>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStaticsRepository, StaticsRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<ILastFiveProductRepository, LastFiveProductRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
		.AllowAnyMethod()
		.SetIsOriginAllowed((host) => true)
		.AllowCredentials();
	});
});

builder.Services.AddHttpClient();
builder.Services.AddSignalR();

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");
//Localhost:1234/swagger/category/ýndex	 yazmak yerine direk signalrhub dizine giriyoruz.
//localhost:1234/signalrhub

app.Run();
