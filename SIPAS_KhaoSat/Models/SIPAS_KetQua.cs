using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_KetQua
    {
        public byte? MaLuaChon { get; set; }

        public int? MaDapAn { get; set; }

        public int? MaCauHoi { get; set; }

        public byte? LoaiThangDo { get; set; }

        public short? Diem { get; set; }

        public long MaDoiTuong { get; set; }

        public virtual SIPAS_DapAn? DapAn { get; set; }

        public virtual SIPAS_LuaChon? LuaChon { get; set; }

        public virtual SIPAS_DoiTuongKhaoSat? DoiTuong { get; set; }
    }

}
