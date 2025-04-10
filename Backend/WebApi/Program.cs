using Database;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);


var corsPolicyName = "AllowFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins("https://localhost:7155") // tu frontend Blazor
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDepartmentService, EfcDepartmentService>();
builder.Services.AddTransient<IStoryService, EfcStoryService>();
builder.Services.AddDbContext<ViaTabloidDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();