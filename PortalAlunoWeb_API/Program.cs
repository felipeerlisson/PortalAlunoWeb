using PortalAlunoWeb_DataAccess.Dapper;
using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Services;
using PortalAlunoWeb_Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("https://localhost:7133",
                            "https://localhost:7126").AllowAnyHeader()
                            .AllowAnyMethod(); ;
    });

}
 );

// Add services to the container.

builder.Services.AddControllers();

// ÁREA PARA ADD OS SERVICES
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IComercioService, ComercioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();




// ÁREA PARA ADD OS REPOSITORY
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IComercioRepository, ComercioRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.MapControllers();

app.Run();
