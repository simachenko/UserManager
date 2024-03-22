using UserManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddUserManagerServices();

#region Add api support

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
	options.JsonSerializerOptions.IgnoreNullValues = true;
});
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region Use requests logging

app.Use(async (context, next) =>
{
	// write to console on each request request path
	Console.WriteLine(context.Request.Path);
	await next();
});

#endregion

#region Use controllers
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
#endregion

app.Run();
