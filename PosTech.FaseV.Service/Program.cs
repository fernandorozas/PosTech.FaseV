using PosTech.FaseV.Application.Gateways;
using PosTech.FaseV.Application;
using PosTech.FaseV.Identity;
using PosTech.FaseV.SqlServer;
using PosTech.FaseV.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddInfraData(builder.Configuration);
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<IUser, CurrentUser>();

var app = builder.Build();

app.UseSwaggerConfig();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGroup("api/account").MapIdentityApi<User>();
app.MapControllers();
app.Run();
