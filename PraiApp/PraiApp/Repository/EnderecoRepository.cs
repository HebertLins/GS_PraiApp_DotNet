using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PraiApp.Models;

namespace PraiApp.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly PraiAppContext _context;

        public EnderecoRepository(PraiAppContext context)
        {
            _context = context;
        }

        public async Task<EnderecoModel> GetEnderecoByIdAsync(int id)
        {
            return await _context.EnderecoModel.FindAsync(id);
        }
    }
}