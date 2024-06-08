using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PraiApp.Models;

namespace PraiApp.Repository
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly PraiAppContext _context;

        public ResponsavelRepository(PraiAppContext context)
        {
            _context = context;
        }

        public async Task<ResponsavelModel> GetResponsavelByIdAsync(int id)
        {
            return await _context.ResponsavelModel.FindAsync(id);
        }
    }
}
