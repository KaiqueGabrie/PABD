using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace Atividade_23_09_API.Models.Dtos
{
    public class EmpresaCriarDto
    {
        [Required(ErrorMessage = "A Razão Social é obrigatória!")]
        public required string? Razao {  get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório!")]
        public required string? Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório!")]
        [Length(14, 14, ErrorMessage = "O CNPJ deve ter no mínimo 14 e no máximo 14 caracteres!")]
        public required string? Cnpj { get; set; }

        [Length(10, 10, ErrorMessage = "O telefone deve ter no mínimo 10 e no máximo 10 caracteres!")]
        [Required(ErrorMessage = "O Telefone é obrigatório!")]
        public required string? Telefone { get; set; }
        [EmailAddress(ErrorMessage = "O E-mail não é válido!")]
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        public required string? Email { get; set; }
        public string? Inscr_estad {  get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória!")]
        public required string? Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório!")]
        [RegularExpression(@"AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO")]
        public required string? Estado { get; set; }

        [Length(8, 8, ErrorMessage = "O CEP deve ter no mínimo 8 e no máximo 8 caracteres!")]
        [Required(ErrorMessage = "O CEP é obrigatório!")]
        public required string? Cep { get; set; }

    }
}
