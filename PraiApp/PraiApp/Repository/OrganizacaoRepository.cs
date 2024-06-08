using PraiApp.Models;

namespace PraiApp.Repository
{
    public class OrganizacaoRepository : IOrganizacaoRepository
    {
        private readonly PraiAppContext _context;

        public OrganizacaoRepository(PraiAppContext context)
        {
            _context = context;
        }

        public async Task<OrganizacaoModel> GetOrganizacaoByIdAsync(long id)
        {
            return await _context.OrganizacaoModel.FindAsync(id);
        }

    }
}
