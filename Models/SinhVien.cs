using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh.Models
{
    public class SinhVien
    {
        [Key]
        public string ID { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }
        public DateTime Namsinh { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }

        public string LopHocPhanID { get; set; }
        [ForeignKey("LopHocPhanID")]
        public virtual LopHocPhan LopHocPhan { get; set; }
        
    }
}
