using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using KravMagaAPI_DAL.Services_DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICRUDServiceDAL<AuthorisationModelDAL>, AuthorisationServiceDAL>();
builder.Services.AddScoped<ICRUDServiceDAL<BeltModelDAL>, BeltServiceDAL>();
builder.Services.AddScoped<LogInServiceDAL>();
builder.Services.AddScoped<ICRUDServiceDAL<MemberModelDAL>, MemberServiceDAL>();
builder.Services.AddScoped<ICRUDServiceDAL<RoleModelDAL>, RoleServiceDAL>();

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
