using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIPAS_KhaoSat.Models
{
    [Table("SIPAS_DoiTuongKhaoSat")]
    public class SIPAS_DoiTuongKhaoSat
    {
        [Key]
        public long MaDoiTuong { get; set; }

        public bool GioiTinh { get; set; }

        public byte DoTuoi { get; set; }

        [ForeignKey("DoTuoi")]
        public virtual SIPAS_DoTuoi? DoTuoiInfo { get; set; }

        public byte? MaDanToc { get; set; }

        [ForeignKey("MaDanToc")]
        public virtual SIPAS_DanToc? DanToc { get; set; }

        public byte? MaHocVan { get; set; }

        [ForeignKey("MaHocVan")]
        public virtual SIPAS_TrinhDoHocVan? TrinhDoHocVan { get; set; }

        public byte? MaNgheNghiep { get; set; }

        [ForeignKey("MaNgheNghiep")]
        public virtual SIPAS_NgheNghiep? NgheNghiep { get; set; }

        public byte? MaNoiSong { get; set; }

        [ForeignKey("MaNoiSong")]
        public virtual SIPAS_NoiSinhSong? NoiSinhSong { get; set; }

        public string? YKienKhac { get; set; }

        public DateTime? NgayKhaoSat { get; set; } = DateTime.Now;

        public int? MaDot { get; set; }

        [ForeignKey("MaDot")]
        public virtual SIPAS_DotKhaoSat? DotKhaoSat { get; set; }
    }
}
