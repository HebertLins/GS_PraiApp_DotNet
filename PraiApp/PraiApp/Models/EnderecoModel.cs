using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PraiApp.Models
{
    [Table("TBL_ENDERECO")]
    public class EnderecoModel
    {
        [Key]
        [Column("id_endereco")]
        [Display(Name = "Código do Endereco")]
        public int IdEndereco { get; set; }

        [Column("rua_endereco")]
        [Display(Name = "Rua")]
        public String RuaEndereco { get; set; }

        [Column("cidade_endereco")]
        [Display(Name = "Cidade")]
        public String CidadeEndereco { get; set; }

        [Column("uf_endereco")]
        [Display(Name = "UF")]
        public String UfEndereco { get; set; }

        [Column("cep_endereco")]
        [Display(Name = "CEP")]
        public String CepEndereco { get; set; }

        public ICollection<OrganizacaoModel> Organizacoes { get; set; } = new List <OrganizacaoModel>();

    }
}
