using System.Threading.Tasks;
using PraiApp.Models;

namespace PraiApp.Repository
{
    public interface IResponsavelRepository
    {
        Task<ResponsavelModel> GetResponsavelByIdAsync(int id);
    }
}
