﻿using LojaTenisAula12.Data;
using LojaTenisAula12.Dto.TenisDto;
using LojaTenisAula12.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAula12.Services
{
    public class TenisService : ITenisInterface
    {

        private readonly AppDbContext _context;
        private readonly string _sistema;

        public TenisService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }

        public async Task<List<TenisModel>> BuscarTenis()
        {
            try
            {

                return await _context.Tenis.ToListAsync();

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TenisModel> BuscarTenisPorId(int? id)
        {
            try
            {

                return await _context.Tenis.FirstOrDefaultAsync(tenis => tenis.Id == id);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TenisModel> Cadastrar(CriarTenisDto criarTenisDto, IFormFile foto)
        {
            try
            {

                var nomeCaminhoImagem = GerarCaminhoArquivo(foto);

                var tenis = new TenisModel
                {
                    Nome = criarTenisDto.Nome,
                    Marca = criarTenisDto.Marca,
                    Valor = criarTenisDto.Valor,
                    Foto = nomeCaminhoImagem
                };


                _context.Add(tenis);
                await _context.SaveChangesAsync();

                return tenis;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarCaminhoArquivo(IFormFile foto)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";

            var caminhoParaSalvarImagens = _sistema + "\\imagem\\";

            if (!Directory.Exists(caminhoParaSalvarImagens))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }


            using (var stream = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
            {
                foto.CopyToAsync(stream).Wait();
            }

            return nomeCaminhoImagem;
        }
    }
}
