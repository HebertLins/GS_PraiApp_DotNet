using PraiApp.Models;

namespace PraiApp.Repository
{
    public interface IEnderecoRepository
    {
        Task<EnderecoModel> GetEnderecoByIdAsync(int id);
    }
}
