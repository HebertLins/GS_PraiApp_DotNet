using PraiApp.Models;

namespace PraiApp.Repository
{
    public interface IOrganizacaoRepository
    {
        Task<OrganizacaoModel> GetOrganizacaoByIdAsync(long id);
    }
}
