using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh.Models
{
    public class LopHocPhan
    {
        [Key]
        public string ID { get; set; }
        public int NamHoc { get; set; }
        public int HocKi { get; set; }
        [StringLength(200)]
        public string Mon { get; set; }
        public float DiemGK { get; set; }
        public float DiemCK { get; set; }
        
        public string KhoaID { get; set; }
        [ForeignKey("KhoaID")]
        public virtual Khoa Khoa { get; set; }

        public string MonHocID { get; set; }
        [ForeignKey("MonHocID")]
        public virtual MonHoc MonHoc { get; set; }
        public ICollection<SinhVien> SinhViens { get; set; }
    }
}
