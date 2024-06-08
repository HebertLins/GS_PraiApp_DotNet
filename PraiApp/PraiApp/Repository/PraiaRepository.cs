using PraiApp.Models;

namespace PraiApp.Repository
{
    public class PraiaRepository : IPraiaRepository
    {
        private readonly PraiAppContext _context;

        public PraiaRepository(PraiAppContext context)
        {
            _context = context;
        }

        public async Task<PraiaModel> GetPraiaByIdAsync(long id)
        {
            return await _context.PraiaModel.FindAsync(id);
        }
    }
}
