using AutoMapper;
using AutoMapperVSMappingManual._2___Application;
using AutoMapperVSMappingManual._2___Application.AutoMapper;
using AutoMapperVSMappingManual._2___Application.Entity.Clientes;
using AutoMapperVSMappingManual._2___Application.Interface;
using AutoMapperVSMappingManual._2___Application.MappingManual;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Clientes>(builder.Configuration.GetSection("Clientes"));


builder.Services.AddScoped<IClienteEntityToClienteView, ClienteEntityToClienteViewModel>();
builder.Services.AddScoped<IMapView, MapView>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
