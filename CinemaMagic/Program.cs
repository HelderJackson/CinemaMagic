using CinemaMagic.DataContexto;
using CinemaMagic.Servico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFilmeServico, FilmeServico>();
builder.Services.AddScoped<ISalaServico, SalaServico>();


builder.Services.AddDbContext<AplicacaoDbContexto>(options =>
{
    var conexao = builder.Configuration.GetConnectionString("sqlConnection");
    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

});


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
