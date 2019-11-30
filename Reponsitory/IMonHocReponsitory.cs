using Microsoft.EntityFrameworkCore;
using QL_Hocsinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh
{
    public interface IMonHocReponsitory
    {
        Task Add(MonHoc monhoc);

        bool Exits(int id);

        Task Update(MonHoc monhoc);

        Task Remove(int id);

        Task<MonHoc> FindById(int id);

        Task<List<MonHoc>> GetAll();
    }
    public class MonHocReponsitory : IMonHocReponsitory
    {
        private KetQuaHocTap context;
        public MonHocReponsitory(KetQuaHocTap _context)
        {
            context = _context;
        }

        public async Task Add(MonHoc monhoc)
        {
            context.Add(monhoc);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
            MonHoc monhoc = context.MonHocs.Find(id);
            if (monhoc != null)
            {
                return true;
            }
            return false;
        }

        public async Task<MonHoc> FindById(int id)
        {
            MonHoc monhoc = await context.MonHocs.FindAsync(id);
            return monhoc;
        }

        public async Task<List<MonHoc>> GetAll()
        {
            return await context.MonHocs.ToListAsync();
        }

        public async Task Remove(int id)
        {
            MonHoc monhoc = await context.MonHocs.FindAsync(id);
            context.Remove(monhoc);
            await context.SaveChangesAsync();
        }

        public async Task Update(MonHoc monhoc)
        {
            MonHoc monhocnew = await context.MonHocs.FindAsync(monhoc.ID);
            monhocnew = monhoc;
            //context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
