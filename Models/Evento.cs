using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime Data { get; set; }
        public required string Local { get; set; }
        [Column(TypeName = "decimal(18,2)")] // Especifica o tipo da coluna SQL
        public decimal Preco { get; set; }
        public int IngressosDisponiveis { get; set; }
    }

    
}
