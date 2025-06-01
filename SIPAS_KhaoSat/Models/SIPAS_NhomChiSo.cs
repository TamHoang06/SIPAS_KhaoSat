using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_NhomChiSo
    {
        [Key]
        public byte MaNhom { get; set; }

        public byte? MaCapCha { get; set; }

        public string TenNhom { get; set; } = null!;

        public virtual SIPAS_NhomChiSo? CapCha { get; set; }
    }

}
