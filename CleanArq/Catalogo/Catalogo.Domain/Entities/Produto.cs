﻿using Catalogo.Domain.Validation;
using System;

namespace Catalogo.Domain.Entities;

public sealed class Produto : Entity
{
    public Produto(string nome, string descricao, decimal preco, string imageUrl,
        int estoque, DateTime dataCadastro)
    {
        ValidateDomain(nome, descricao, preco, imageUrl, estoque, dataCadastro);
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public string ImageUrl { get; private set; }
    public int Estoque { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public void Update(string nome, string descricao, decimal preco, string imageUrl, 
        int estoque, DateTime dataCadastro, int categoriaId)
    {
        ValidateDomain(nome, descricao, preco, imageUrl, estoque, dataCadastro);
        CategoriaId = categoriaId;
    }

    private void ValidateDomain(string nome, string descricao, decimal preco, string imageUrl, 
        int estoque, DateTime dataCadastro)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
            "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
            "Descrição inválida. A descrição é obrigatória");

        DomainExceptionValidation.When(descricao.Length < 5,
            "A descrição deve ter no mínimo 5 caracteres");

        DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

        DomainExceptionValidation.When(imageUrl?.Length > 250,
            "O nome da image não pode exceder 250 caracteres");

        DomainExceptionValidation.When(estoque < 0, "Estoque inválido");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImageUrl = imageUrl;
        Estoque = estoque;
        DataCadastro = dataCadastro;

    }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
