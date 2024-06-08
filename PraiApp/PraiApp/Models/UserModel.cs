using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PraiApp.Models
{
    [Table("TBL_USER")]
    public class UserModel
    {
        [Key]
        [Column("ID_USER")]
        [Display(Name = "Código do Usuário")]
        public long Id { get; set; }

        [Column("NM_USER")]
        [Display(Name = "Nome do Usuário")]
        public string Name { get; set; }

        [Column("EMAIL_USER")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        [Display(Name = "Email do Usuário")]
        public string Email { get; set; }

        [Column("SENHA_USER")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha do Usuário")]
        public string Senha { get; set; }

        [ForeignKey("Organizacao")]
        [Display(Name = "Código da Organizacao")]
        public long IdOrganizacao { get; set; }
        public virtual OrganizacaoModel? Organizacao { get; set; }
    }
}
