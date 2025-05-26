using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities;

public sealed class Categoria : Entity
{
    public Categoria(string nome, string imageUrl)
    {
        ValidateDomain(nome, imageUrl);
    }

    public Categoria(int id, string nome, string imageUrl)
    {
        DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
        Id = id;
        ValidateDomain(nome, imageUrl);
    }

    public string Nome { get; private set; }
    public string ImageUrl { get; private set; }
    public ICollection<Produto> Produtos { get; set; }

    private void ValidateDomain(string nome, string imageUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl),
            "Nome da image inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
           "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(imageUrl.Length < 5,
            "Nome da image deve ter no mínimo 5 caracteres");

        Nome = nome;
        ImageUrl = imageUrl;
    }
}
