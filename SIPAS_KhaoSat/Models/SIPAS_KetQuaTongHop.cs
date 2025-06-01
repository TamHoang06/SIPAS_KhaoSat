namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_KetQuaTongHop
    {
        public byte? MaLuaChon { get; set; }

        public int? MaDapAn { get; set; }

        public int? MaCauHoi { get; set; }

        public byte? LoaiThangDo { get; set; }

        public short? Diem { get; set; }

        public int? SoNguoiChon { get; set; }

        public int? TongDiem { get; set; }

        public int? MaDot { get; set; }

        public virtual SIPAS_DapAn? DapAn { get; set; }

        public virtual SIPAS_LuaChon? LuaChon { get; set; }

        public virtual SIPAS_DotKhaoSat? DotKhaoSat { get; set; }
    }

}
