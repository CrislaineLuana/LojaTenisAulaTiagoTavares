﻿using LojaTenisAula12.Data;
using LojaTenisAula12.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAula12.Services
{
    public class TenisService : ITenisInterface
    {

        private readonly AppDbContext _context;

        public TenisService(AppDbContext context)
        {
            _context = context;
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
    }
}
