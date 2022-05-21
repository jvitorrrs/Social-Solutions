using System.ComponentModel.DataAnnotations;

namespace Social_Solutions.Models
{
    public class Imoveis
    {
        [Key]
        public int Id_Imovel { get; set; }
        public string? Tipo_Negocio { get; set; }
        public int Valor { get; set; }
        public string? Descricao { get; set; }
        public string? Imovel_Ativo { get; set; }
        public int Id_Cliente { get; set; }
    }
}
