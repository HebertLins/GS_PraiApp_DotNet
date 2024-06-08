using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PraiApp.Models
{
    [Table("TBL_AVALIACAO")]
    public class AvaliacaoModel
    {
        [Key]
        [Column("ID_AVALIACAO")]
        [Display(Name = "Código da Avaliação")]
        public int IdAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("LIMPEZA_AVALIACAO")]
        [Display(Name = "Avaliação da Limpeza")]
        public double LimpezaAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("ESTRUTURA_AVALIACAO")]
        [Display(Name = "Avaliação da Estrutura")]
        public double EstruturaAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("SINALIZACAO_AVALIACAO")]
        [Display(Name = "Avaliação da Sinalização")]
        public double SinalizacaoAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("MONITORAMENTO_AVALIACAO")]
        [Display(Name = "Avaliação do Monitoramneto")]
        public double MonitoramentoAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("POLUICAO_AVALIACAO")]
        [Display(Name = "Avaliação da Poluição")]
        public double PoluicaoAvaliacao { get; set; }

        [Range(0, 5, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
        [Column("CONSERVACAO_AMBIENTAL_AVALIACAO")]
        [Display(Name = "Avaliação da Conservação Ambiental")]
        public double ConservacaoAvaliacao { get; set; }

        [ForeignKey("User")]
        [Display(Name = "Código do Usuário")]
        public long IdUser { get; set; }
        public virtual UserModel? User { get; set; }

        [ForeignKey("Praia")]
        [Display(Name = "Código da Praia")]
        public long IdPraia { get; set; }
        public virtual PraiaModel? Praia { get; set; }
    }
}