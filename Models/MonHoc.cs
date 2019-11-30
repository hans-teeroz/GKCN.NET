using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh.Models
{
    public class MonHoc
    {
        [Key]
        public string ID { get; set; }
        [StringLength(200)]
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }
        public ICollection<LopHocPhan> LopHocPhans { get; set; }
    }
}
