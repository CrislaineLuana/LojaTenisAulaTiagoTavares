using LojaTenisAula12.Dto.TenisDto;
using LojaTenisAula12.Models;

namespace LojaTenisAula12.Services
{
    public interface ITenisInterface
    {
        Task<List<TenisModel>> BuscarTenis();
        Task<TenisModel> BuscarTenisPorId(int? id);
        Task<TenisModel> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto);
    }
}
