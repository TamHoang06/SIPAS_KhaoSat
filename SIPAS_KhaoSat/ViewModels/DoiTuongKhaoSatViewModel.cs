using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.ViewModels
{
    public class DoiTuongKhaoSatViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public bool? GioiTinh { get; set; }
        public byte DoTuoi { get; set; }
        public byte MaDanToc { get; set; }
        public string? DanTocKhac { get; set; }
        public byte MaHocVan { get; set; }
        public string? HocVanKhac { get; set; }
        public byte MaNgheNghiep { get; set; }
        public string? NgheNghiepKhac { get; set; }
        public byte MaNoiSong { get; set; }
        public string? NoiSongKhac { get; set; }
        public int? MaDot { get; set; }
    }
}
