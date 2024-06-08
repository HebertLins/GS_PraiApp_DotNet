using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PraiApp.Models
{
    [Table("TBL_PRAIA")]
    public class PraiaModel
    {
        [Key]
        [Column("ID_PRAIA")]
        [Display(Name = "Código da Praia")]
        public long IdPraia { get; set; }

        [Column("NOME_PRAIA")]
        [Display(Name = "Nome da Praia")]
        public string NomePraia { get; set; }

        [Column("DESC_PRAIA")]
        [Display(Name = "Descrição da Praia")]
        public string DescPraia { get; set; }

        [Column("LIMPEZA_PRAIA")]
        [Display(Name = "Avaliação Geral de Limpeza")]
        public double TotLimpezaPraia { get; set; }

        [Column("ESTRUTURA_PRAIA")]
        [Display(Name = "Avaliação Geral de Estrutura")]
        public double TotEstruturaPraia { get; set; }

        [Column("SINALIZACAO_PRAIA")]
        [Display(Name = "Avaliação Geral de Sinalização")]
        public double TotSinalizacaoPraia { get; set; }

        [Column("MONITORAMENTO_PRAIA")]
        [Display(Name = "Avaliação Geral do Monitoramento")]
        public double TotMonitoramentoPraia { get; set; }

        [Column("POLUICAO_PRAIA")]
        [Display(Name = "Avaliação Geral da Poluição")]
        public double TotPoluicaoPraia { get; set; }

        [Column("CONSERVACAO_AMBIENTAL_PRAIA")]
        [Display(Name = "Avaliação Geral da Conservação Ambiental")]
        public double TotConservacaoPraia { get; set; }

        [Column("TOTAL_PRAIA")]
        [Display(Name = "Avaliação Geral da Praia")]
        public double TotalPraia { get; set; }

        [ForeignKey("Endereco")]
        [Display(Name = "Código do Endereco")]
        public int IdEndereco { get; set; }

        public virtual EnderecoModel? Endereco { get; set; }
    }
}
