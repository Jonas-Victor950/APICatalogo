using APICatalogo.Context;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoxUnitTests.UnitTests;

public class ProdutosUnitTestController
{
    public IUnitOfWork repository;
    public IMapper mapper;
    public static DbContextOptions<AppDbContext> dbContextOptions { get; }
    public static string connectionString =
      "Server=localhost;Port=3306;Database=catalogo_db;Uid=root;Pwd=@Lindo2849;";
    static ProdutosUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
           .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
           .Options;
    }
   public ProdutosUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProdutoDTOMappingProfile());
        });

        mapper = config.CreateMapper();

        var context = new AppDbContext(dbContextOptions);
        repository = new UnitOfWork(context);
    }

    //criar testes de unidade
}
