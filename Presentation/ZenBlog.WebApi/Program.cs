using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;
using ZenBlog.WebApi.CustomMiddlewares;
using ZenBlog.WebApi.EndPoints.Registration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("/api")
    .RequireAuthorization()
    .RegisterEndPoints();
//app.MapGroup("/api")
//    .RegisterEndPoints();
app.Run();
