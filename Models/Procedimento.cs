using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalLiriany.Models
{

    [Table("Procedimento")]
    public class Procedimento
    {
        [Column("ProcedimentoId")]
        [Display(Name = "Código do Procedimento")]
        public int ProcedimentoId { get; set; }

        [Column("ProcedimentoNome")]
        [Display(Name = "Nome do Procedimento")]
        public string ProcedimentoNome { get; set; } = string.Empty;

        [Column("ProcedimentoObservacao")]
        [Display(Name = "Observação do Procedimento")]
        public string ProcedimentoObservacao { get; set; } = string.Empty;

        [ForeignKey("TipoProcedimentoId")]

        public int TipoProcedimentoId { get; set; }

        public TipoProcedimento? TipoProcedimento { get; set; }
    }
}
