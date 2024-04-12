using LojaTenisAula12.Models;
using LojaTenisAula12.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaTenisAula12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITenisInterface _tenisInterface;
        public HomeController(ITenisInterface tenisInterface)
        {
            _tenisInterface = tenisInterface;
        }

        public async Task<IActionResult> Index(string? pesquisar)
        {
            if(pesquisar == null)
            {
                var tenis = await _tenisInterface.BuscarTenis();
                return View(tenis);
            }
            else
            {
                var tenis = await _tenisInterface.BuscarTenisFiltro(pesquisar);
                return View(tenis);
            }
            
        }

        
    }
}
