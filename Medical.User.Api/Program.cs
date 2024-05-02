using Medical.User.Application.Extensions;
using Medical.User.Infra.Extensions;
using Smart.Essentials.Filters;
using Smart.Essentials.Security.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services
    .AddControllers
    (
        options =>
        {
            options.Filters.Add(typeof(DefaultExceptionFilterAttribute));
            options.Filters.Add(typeof(ValidationFilter));
        }
    )
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureJwt();
builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
