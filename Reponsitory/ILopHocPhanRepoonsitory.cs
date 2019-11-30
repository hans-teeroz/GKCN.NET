using Microsoft.EntityFrameworkCore;
using QL_Hocsinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh
{
    public interface ILopHocPhanRepoonsitory
    {
        Task Add(LopHocPhan lop);

        bool Exits(int id);

        Task Update(LopHocPhan lop);

        Task Remove(int id);

        Task<LopHocPhan> FindById(int id);

        Task<List<LopHocPhan>> GetAll();
    }
    public class LopHocPhanReponsitory : ILopHocPhanRepoonsitory
    {
        private KetQuaHocTap context;
        public LopHocPhanReponsitory(KetQuaHocTap _context)
        {
            context = _context;
        }

        public async Task Add(LopHocPhan lop)
        {
            context.Add(lop);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
            LopHocPhan lop = context.LopHocPhans.Find(id);
            if (lop != null)
            {
                return true;
            }
            return false;
        }

        public async Task<LopHocPhan> FindById(int id)
        {
            LopHocPhan lop = await context.LopHocPhans.FindAsync(id);
            return lop;
        }

        public async Task<List<LopHocPhan>> GetAll()
        {
            return await context.LopHocPhans.ToListAsync();
        }

        public async Task Remove(int id)
        {
            LopHocPhan lop = await context.LopHocPhans.FindAsync(id);
            context.Remove(lop);
            await context.SaveChangesAsync();
        }

        public async Task Update(LopHocPhan lop)
        {
            LopHocPhan lopnew = await context.LopHocPhans.FindAsync(lop.ID);
            lopnew = lop;
            //context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
