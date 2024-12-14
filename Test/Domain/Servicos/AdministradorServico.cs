using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        // Configuração do builder para ler o arquivo de configuração
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        // Construção da configuração
        var configuration = builder.Build();

        // Recupera a string de conexão do arquivo appsettings.json
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configura as opções do DbContext
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseSqlServer(connectionString)
            .Options;

        // Retorna a instância do contexto
        return new DbContexto((IConfiguration)options);
    }
    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var adm = new Administrador();

        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        // Act
        var context = CriarContextoDeTeste();

        // Assert
        // testa os get
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
        
    }
}