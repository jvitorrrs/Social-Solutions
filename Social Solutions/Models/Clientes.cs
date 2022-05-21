using System.ComponentModel.DataAnnotations;

namespace Social_Solutions.Models
{
    public class Clientes
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int CPF { get; set; }
        public string? Cliente_Ativo { get; set; }
    }
}
