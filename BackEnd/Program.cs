using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CursosContext>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

//DALs
builder.Services.AddScoped<IUsuarioDAL, UsuarioDALImpl>();
builder.Services.AddScoped<ICursoDAL, CursoDALImpl>();
builder.Services.AddScoped<IEventoDAL, EventoDALImpl>();
builder.Services.AddScoped<IRatingDAL, RatingDALImpl>();
builder.Services.AddScoped<ITemaDAL, TemaDALImpl>();
builder.Services.AddScoped<IVideoDAL, VideoDALImpl>();
builder.Services.AddScoped<IHistorialCursoDAL, HistorialCursoDALImpl>();
builder.Services.AddScoped<ISolicitudInfoDAL, SolicitudInfoDALImpl>();


//Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<ITemaService, TemaService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IHistorialCursoService, HistorialCursoService>();
builder.Services.AddScoped<ISolicitudInfoService, SolicitudInfoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
