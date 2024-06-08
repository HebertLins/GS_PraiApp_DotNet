using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraiApp.Models
{
    [Table("TBL_ORGANIZACAO")]
    public class OrganizacaoModel
    {
        [Key]
        [Column("ID_ORGANIZACAO")]
        [Display(Name = "Código da Organização")]
        public long IdOrganizacao { get; set; }

        [Column("NM_ORGANIZACAO")]
        [Display(Name = "Nome da Organização")]
        public string NomeOrganizacao { get; set; }

        [Column("DESC_ORGANIZACAO")]
        [Display(Name = "Descrição da Organização")]
        public string DescricaoOrganizacao { get; set; }

        [Column("TP_ORGANIZACAO")]
        [Display(Name = "Tipo da Organização")]
        public string TipoOrganizacao { get; set; }

        [Required(ErrorMessage = "O CNPJ da organização é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Um CNPJ deve conter 14 dígitos.")]
        [Column("CNPJ_ORGANIZACAO")]
        [Display(Name = "CNPJ da Organização")]
        public string CnpjOrganizacao { get; set; }

        [ForeignKey("Endereco")]
        [Display(Name = "Código do Endereco")]
        public int IdEndereco { get; set; }

        [ForeignKey("Responsavel")]
        [Display(Name = "Código do Responsavel")]
        public int IdResponsavel { get; set; }

        public virtual EnderecoModel? Endereco { get; set; }

        public virtual ResponsavelModel? Responsavel { get; set; }

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();



    }
}
