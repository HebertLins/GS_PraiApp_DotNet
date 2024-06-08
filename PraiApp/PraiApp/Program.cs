using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PraiApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string StringConexao = "User Id=rm96967;Password=010702;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=orcl)));";

builder.Services.AddDbContext<PraiAppContext>
    (options => options.UseOracle(StringConexao));

// Configuração de Repository
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPraiaRepository, PraiaRepository>();
builder.Services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();

// Adicionar suporte à localização
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Adicionar suporte à localização para os controladores
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var options = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


