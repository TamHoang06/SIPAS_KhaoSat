using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_LuaChon
    {
        [Key]
        public byte MaLuaChon { get; set; }
        public byte? MaNhomLuaChon { get; set; }
        public string Nhan { get; set; } = null!;
        public short Diem { get; set; }
        public virtual SIPAS_NhomLuaChon? NhomLuaChon { get; set; }
    }

}
