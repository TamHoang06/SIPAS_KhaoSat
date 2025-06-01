using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_NhomLuaChon
    {
        [Key]
        public byte MaNhomLuaChon { get; set; }

        public string TenNhom { get; set; } = null!;

        public byte SoLuaChon { get; set; }

        public string? GhiChu { get; set; }

        public virtual ICollection<SIPAS_LuaChon>? LuaChons { get; set; } = new List<SIPAS_LuaChon>();
    }

}
