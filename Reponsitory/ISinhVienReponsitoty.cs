using Microsoft.EntityFrameworkCore;
using QL_Hocsinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh
{
    public interface ISinhVienReponsitoty
    {
        Task Add(SinhVien sinhvien);

        bool Exits(int id);

        Task Update(SinhVien sinhvien);

        Task Remove(int id);

        Task<SinhVien> FindById(int id);

        Task<List<SinhVien>> GetAll();
    }
    public class SinhVienReponsitoty : ISinhVienReponsitoty
    {
        private KetQuaHocTap context;
        public SinhVienReponsitoty(KetQuaHocTap _context)
        {
            context = _context;
        }

        public async Task Add(SinhVien sinhvien)
        {
            context.Add(sinhvien);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
           SinhVien sinhvien = context.SinhViens.Find(id);
            if (sinhvien != null)
            {
                return true;
            }
            return false;
        }

        public async Task<SinhVien> FindById(int id)
        {
            SinhVien sinhvien = await context.SinhViens.FindAsync(id);
            return sinhvien;
        }

        public async Task<List<SinhVien>> GetAll()
        {
            return await context.SinhViens.ToListAsync();
        }

        public async Task Remove(int id)
        {
            SinhVien sinhvien = await context.SinhViens.FindAsync(id);
            context.Remove(sinhvien);
            await context.SaveChangesAsync();
        }

        public async Task Update(SinhVien sinhvien)
        {
            SinhVien sinhviennew = await context.SinhViens.FindAsync(sinhvien.ID);
            sinhviennew = sinhvien;
            //context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
