using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL_Hocsinh.Models;

namespace QL_Hocsinh.Controllers
{

    public class HomeController : Controller
    {
        private ISinhVienReponsitoty postReponsitory;
        //public HomeController(KetQuaHocTap _db)
        //{
        //    db = _db;
        //}
        public HomeController(ISinhVienReponsitoty _postReponsitory)
        {
            postReponsitory = _postReponsitory;
        }
        public async Task<IActionResult> Index()
        {
            List<SinhVien> sinhViens = await postReponsitory.GetAll();
            return View(sinhViens);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
