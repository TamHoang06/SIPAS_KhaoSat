using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DoiTuongKhaoSat
    {
        [Key]
        public long MaDoiTuong { get; set; }

        public bool GioiTinh { get; set; }

        public byte DoTuoi { get; set; }

        public byte? MaDanToc { get; set; }

        public byte? MaHocVan { get; set; }

        public byte? MaNgheNghiep { get; set; }

        public byte? MaNoiSong { get; set; }

        public string? YKienKhac { get; set; }

        public DateTime? NgayKhaoSat { get; set; } = DateTime.Now;

        public int? MaDot { get; set; }

        public virtual SIPAS_DotKhaoSat? DotKhaoSat { get; set; }
        public virtual SIPAS_DoTuoi? DoTuoiInfo { get; set; }
        public SIPAS_DanToc? DanToc { get; set; }
        public SIPAS_TrinhDoHocVan? TrinhDoHocVan { get; set; }
        public SIPAS_NgheNghiep? NgheNghiep { get; set; }
        public SIPAS_NoiSinhSong? NoiSinhSong { get; set; }

    }


}
