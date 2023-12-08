using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalLiriany.Models
{
    [Table("TipoColaborador")]
    public class TipoColaborador
    {
        [Column("TipoColaboradorId")]
        [Display(Name = "Código do Tipo Colaborador")]
        public int TipoColaboradorId { get; set; }

        [Column("TipoColaboradorNome")]
        [Display(Name = "Nome do Tipo do Colaborador")]

        public string TipoColaboradorNome { get; set; } = string.Empty;
    }
}
