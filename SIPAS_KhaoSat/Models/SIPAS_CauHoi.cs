using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_CauHoi
    {
        [Key]
        public int MaCauHoi { get; set; }

        public byte? MaNhom { get; set; }

        public string? NoiDung { get; set; }

        public byte? LoaiThangDo { get; set; }

        public byte? MaNhomLuaChon { get; set; }

        public bool BatBuoc { get; set; }

        public bool ChonNhieu { get; set; }

        public byte SoLuongChon { get; set; }

        public bool SuDung { get; set; }

        public virtual SIPAS_NhomChiSo? NhomChiSo { get; set; }

        public virtual SIPAS_NhomLuaChon? NhomLuaChon { get; set; }

        public virtual ICollection<SIPAS_DapAn>? DapAns { get; set; }
    }


}
