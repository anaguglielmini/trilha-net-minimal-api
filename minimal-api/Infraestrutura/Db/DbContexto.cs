// dados de configuração do Entity Framework
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;
public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Obtém a string de conexão do appsettings.json
        var stringConexao = _configuracaoAppSettings.GetConnectionString("DefaultConnection");

        // Verifica se a string de conexão é nula ou vazia
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseSqlServer(stringConexao);
        }
        else
        {
            throw new InvalidOperationException("String de conexão não configurada.");
        }
    }
} 