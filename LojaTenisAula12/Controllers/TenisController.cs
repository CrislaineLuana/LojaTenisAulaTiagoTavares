using LojaTenisAula12.Dto.TenisDto;
using LojaTenisAula12.Models;
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

        public IActionResult Cadastrar()
        {
            return View();
        }


        public async Task<IActionResult> Editar(int? id)
        {

            if(id != null)
            {
                var tenis = await _tenisInterface.BuscarTenisPorId(id);
                return View(tenis);
            }

            return RedirectToAction("Index");

        }



        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                var tenis = await _tenisInterface.Cadastrar(criarTenisDto, foto);

                TempData["MensagemSucesso"] = "Tenis cadastrado com sucesso!";

                return RedirectToAction("Index", "Tenis");
            }
            else
            {

                TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar o tenis!";
                return View(criarTenisDto);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Editar(TenisModel tenisModel, IFormFile? foto)
        {
            if (ModelState.IsValid)
            {

                var tenis = await _tenisInterface.Editar(tenisModel, foto);
                TempData["MensagemSucesso"] = "Tenis editado com sucesso!";
                return RedirectToAction("Index", "Tenis");

            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro ao editar o tenis";
                return View(tenisModel);
            }
        }


    }
}
