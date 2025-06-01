using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DotKhaoSat
    {
        [Key]
        public int MaDot { get; set; }

        public string TenDot { get; set; } = null!;

        public string? MoTa { get; set; }

        public DateTime BatDau { get; set; }

        public DateTime? KetThuc { get; set; }

        public virtual ICollection<SIPAS_CauHoi>? CauHois { get; set; }
    }

}
