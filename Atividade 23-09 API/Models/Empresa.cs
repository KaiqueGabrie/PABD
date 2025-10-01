using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_23_09_API.Models
{
    [Table("empresas")] // table do banco de dados
    public class Empresa
    {
        [Column("id")] // declarando colunas da table
        public int Id { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Column("razao")]
        public string? Razao { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("inscr_estad")]
        public string? Inscr_estad {  get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("email")]
        public string? Email {  get; set; }

        [Column("cidade")]
        public string? Cidade { get; set; }

        [Column("estado")]
        public string? Estado { get; set; }

        [Column("cep")]
        public string? Cep {  get; set; }

        [Column("data_cad")]
        public DateTime? Data_cad {  get; set; }
    }
}
