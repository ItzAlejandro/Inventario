using InventarioProductos.API.Middleware;
using InventarioProductos.Aplicacion;
using InventarioProductos.Exterior;
using InventariosProductos.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AgregarAplicacion();
builder.Services.AgregarPersistencia();
builder.Services.AgregarExterior(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaPermitirFrontend",
        corsBuilder =>
        {
            corsBuilder.WithOrigins(allowedOrigins)
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithExposedHeaders("X-Paginacion");
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseManejadorExceptiones();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("PoliticaPermitirFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
