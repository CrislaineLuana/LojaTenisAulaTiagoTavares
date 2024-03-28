using LojaTenisAula12.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaTenisAula12.Controllers
{
    public class TenisController : Controller
    {
        private readonly ITenisInterface _tenisInterface;
        public TenisController(ITenisInterface tenisInterface)
        {
            _tenisInterface = tenisInterface;
        }

        public async Task<IActionResult> Index()
        {
            var tenis = await _tenisInterface.BuscarTenis();
            return View(tenis);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            var tenis = await _tenisInterface.BuscarTenisPorId(id);
            return View(tenis);
        }


    }
}
