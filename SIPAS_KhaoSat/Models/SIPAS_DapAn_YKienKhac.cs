using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DapAn_YKienKhac
    {
        [Key, ForeignKey("DapAn")]
        public int MaDapAn { get; set; }

        public string YKienKhac { get; set; } = null!;

        public virtual SIPAS_DapAn DapAn { get; set; } = null!;
    }


}
