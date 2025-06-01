using System.ComponentModel.DataAnnotations;

namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DoTuoi
    {
        [Key]
        public byte MaDoTuoi { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenDoTuoi { get; set; }

        public virtual ICollection<SIPAS_DoiTuongKhaoSat> DoiTuongs { get; set; }
    }

}
