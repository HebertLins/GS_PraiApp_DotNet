using PraiApp.Models;

namespace PraiApp.Repository
{
    public interface IPraiaRepository
    {
        Task<PraiaModel> GetPraiaByIdAsync(long id);
    }
}
