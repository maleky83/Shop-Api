using Serilog;
using Shop.Api.Extensions;
using Shop.Api.Middlewares;
using Shop.Application.Extensions;
using Shop.Domain.Entities;
using Shop.Infrastructure.Extensions;
using Shop.Infrastructure.Seeders;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastrucure(builder.Configuration);

WebApplication app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IShopSeeder>();

await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddle>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
