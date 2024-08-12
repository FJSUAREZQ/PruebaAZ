using _1.DAL.DataContext;
using _1.DALL.Repositories._Category;
using _1.DALL.Repositories._Customer;
using _1.DALL.Repositories._GenericRepository;
using _1.DALL.Repositories._Order;
using _1.DALL.Repositories._OrderDetail;
using _1.DALL.Repositories._Product;
using _1.DALL.Repositories._ProductoCategory;
using _1.DALL.UnitOfWork;
using _2.BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

///------------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<SanaDbContext>
        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("_connectionString")));


//--------------------------- Services
//Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();
builder.Services.AddScoped<IRepositoryOrder, RepositoryOrder>();
builder.Services.AddScoped<IRepositoryOrderDetail, RepositoryOrderDetail>();
builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IRepositoryProductCategory, RepositoryProductCategory>();

//Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Other Services
builder.Services.AddScoped<ISanaServices, SanaServices>();


//--------------------------- Enable CORS
builder.Services.AddCors(options => 
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin() 
        .AllowAnyHeader() // JSON content, eetc.
        .AllowAnyMethod(); // GET, POST ...
    });
} );

///------------------------------------------------------------------------------------------------------------



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

app.UseCors("NewPolicy"); //Add CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
