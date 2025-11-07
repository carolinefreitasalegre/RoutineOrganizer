using Application.AutoMapper;
using Application.Dtos.Request;
using Application.Interfaces;
using Application.Services;
using Application.Validator;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Reository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IFilhoRepository, FilhoRepository>();
builder.Services.AddScoped<IRotinaRepository, RotinaRepository>();
builder.Services.AddScoped<ILembreteRepository, LembreteRepository>();
builder.Services.AddScoped<ITarefaDomesticaRepository, TarefaDomesticaRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IFilhoService, FilhoService>();
builder.Services.AddScoped<IRotinaService, RotinaService>();
builder.Services.AddScoped<ITarefaDomesticaService, TarefaDomesticaService>();
builder.Services.AddScoped<ILembreteService, LembreteService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddTransient<IValidator<UsuarioRequest>, AdicionarUsuarioValidator>();
builder.Services.AddTransient<IValidator<FilhoRequest>, AdicionarFilhoValidator>();
builder.Services.AddTransient<IValidator<RotinaRequest>, AdicionarRotinaValidator>();
builder.Services.AddTransient<IValidator<TarefaRequest>, AdicionarTarefaValidator>();
builder.Services.AddTransient<IValidator<LembreteRequest>, AdicionarLembreteValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
