using LojaTenisAula12.Models;

namespace LojaTenisAula12.Services
{
    public interface ITenisInterface
    {
        Task<List<TenisModel>> BuscarTenis();
        Task<TenisModel> BuscarTenisPorId(int? id);
    }
}
