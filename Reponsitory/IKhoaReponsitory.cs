using Microsoft.EntityFrameworkCore;
using QL_Hocsinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh
{
    public interface IKhoaReponsitory
    {
        Task Add(Khoa khoa);

        bool Exits(int id);

        Task Update(Khoa khoa);

        Task Remove(int id);

        Task<Khoa> FindById(int id);

        Task<List<Khoa>> GetAll();
    }
    public class CategoryReponsitory : IKhoaReponsitory
    {
        private KetQuaHocTap context;
        public CategoryReponsitory(KetQuaHocTap _context)
        {
            context = _context;
        }

        public async Task Add(Khoa khoa)
        {
            context.Add(khoa);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
            Khoa khoa = context.Khoas.Find(id);
            if (khoa != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Khoa> FindById(int id)
        {
            Khoa khoa = await context.Khoas.FindAsync(id);
            return khoa;
        }

        public async Task<List<Khoa>> GetAll()
        {
            return await context.Khoas.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Khoa khoa = await context.Khoas.FindAsync(id);
            context.Remove(khoa);
            await context.SaveChangesAsync();
        }

        public async Task Update(Khoa khoa)
        {
            Khoa khoanew = await context.Khoas.FindAsync(khoa.ID);
            khoanew = khoa;
            //context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
