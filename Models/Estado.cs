using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalLiriany.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Column("EstadoId")]
        [Display(Name = "Código do Estado")]
        public int EstadoId { get; set; }

        [Column("EstadoNome")]
        [Display(Name = "Nome do Estado")]

        public string EstadoNome { get; set; } = string.Empty;
    }
}
