using System.ComponentModel.DataAnnotations; // para colocar anotações, Required, MinLenght

namespace APIservico.Models.Dtos

{
    public class ChamadoDto // criado para aparecer somente titulo e descrição, sem id
    {

        [Required(ErrorMessage = "O título é obrigatório!")]
        [Length(10, 100, ErrorMessage = "O título deve ter no mínimo 10 e no máximo 100 caracteres!")]
        [MinLength(10)]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        public required string Descricao {  get; set; }
    }
}
