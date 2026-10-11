using Serilog;
using ShopManagementSystem.Api.Extensions;
using ShopManagementSystem.Api.Middlewares;
using ShopManagementSystem.Application.Extensions;
using ShopManagementSystem.Domain.Entities;
using ShopManagementSystem.Domain.Extensions;
using ShopManagementSystem.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastrucure(builder.Configuration);

WebApplication app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddle>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<User>();

//app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

await app.RunAsync();
