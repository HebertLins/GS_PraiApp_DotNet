using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraiApp.Models
{

    [Table("TBL_RESPONSAVEL")]
    public class ResponsavelModel
    {

        [Key]
        [Column("id_responsavel")]
        [Display(Name = "Código do Responsável")]
        public int IdResponsavel { get; set; }

        [Column("nm_responsavel")]
        [Display(Name = "Nome Responsavel")]
        public String NomeResponsavel { get; set; }

        [Required(ErrorMessage = "O CPF do responsável é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Um CPF deve conter 11 dígitos.")]
        [Column("CPF_RESPONSAVEL")]
        [Display(Name = "CPF Responsavel")]
        public String CpfResponsavel { get; set; }

        public ICollection<OrganizacaoModel> Organizacoes { get; set; } = new List<OrganizacaoModel>();
    }
}
