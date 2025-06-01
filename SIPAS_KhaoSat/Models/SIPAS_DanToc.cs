using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DanToc
    {
        [Key]
        public byte MaDanToc { get; set; }
        [Required]
        public string TenDanToc { get; set; } = string.Empty;
    }
}
