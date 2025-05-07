using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
   public CategoriaRepository(AppDbContext context) : base(context)
   {

   }

   public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
   {
      var categorias = GetAll().OrderBy(p => p.CategoriaId).AsQueryable();
      var categoriasOrdenados = PagedList<Categoria>.ToPagedList(categorias,
                 categoriasParameters.PageNumber, categoriasParameters.PageSize);

      return categoriasOrdenados;
   }
}
