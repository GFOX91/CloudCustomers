using CloudCustomers.Api.Config;
using CloudCustomers.Api.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
ConfigureOptions(builder.Services);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureOptions(IServiceCollection services)
{
    services.Configure<UsersApiOptions>(
        builder.Configuration.GetSection("UsersApiOptions")
    );
}

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IUsersService, UsersService>();
    services.AddHttpClient<IUsersService, UsersService>();
}