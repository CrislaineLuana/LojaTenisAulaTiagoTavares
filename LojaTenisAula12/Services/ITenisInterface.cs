using LojaTenisAula12.Dto.TenisDto;
using LojaTenisAula12.Models;

namespace LojaTenisAula12.Services
{
    public interface ITenisInterface
    {
        Task<List<TenisModel>> BuscarTenis();

        Task<List<TenisModel>> BuscarTenisFiltro(string? pesquisar);

        Task<TenisModel> BuscarTenisPorId(int? id);
        Task<TenisModel> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto);

        Task<TenisModel> Editar(TenisModel tenisModel, IFormFile? foto);


    }
}
