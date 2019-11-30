using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh.Models
{
    public class Khoa
    {
        [Key]
        public string ID { get; set; }
        [StringLength(400)]
        public string TenKhoa { get; set; }
        public ICollection<LopHocPhan> LopHocPhans { get; set; }
    }
}
