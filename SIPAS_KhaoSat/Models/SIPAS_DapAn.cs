using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DapAn
    {
        [Key]
        public int MaDapAn { get; set; }

        public int? MaCauHoi { get; set; }

        public string? NoiDung { get; set; }

        public bool YKienKhac { get; set; }

        public virtual SIPAS_CauHoi? CauHoi { get; set; }

        public virtual SIPAS_DapAn_YKienKhac? YKienKhacNoiDung { get; set; }
    }


}
