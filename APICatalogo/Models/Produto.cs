using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APICatalogo.Validations;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto : IValidatableObject
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(20, ErrorMessage = "O nome deve ter entre 5 e 20 caracteres", MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
    public string? Descricao { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "O preço deve estar entre 1 e 10000")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 10)]
    public string? ImageUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraLetra = this.Nome[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new ValidationResult("A primeira letra do nome do produto deve ser maiuscula", new[] { nameof(this.Nome) });
            }
        }
        if (this.Estoque <= 0)
        {
            yield return new ValidationResult("O estoque deve ser maior que zero", new[] { nameof(this.Estoque) });
        }
    }
}
