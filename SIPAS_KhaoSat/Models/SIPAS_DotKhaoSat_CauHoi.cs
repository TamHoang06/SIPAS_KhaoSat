namespace SIPAS_KhaoSat.Models
{
    public class SIPAS_DotKhaoSat_CauHoi
    {
        public int? MaDot { get; set; }

        public int? MaCauHoi { get; set; }

        public virtual SIPAS_CauHoi? CauHoi { get; set; }

        public virtual SIPAS_DotKhaoSat? DotKhaoSat { get; set; }
    }

}
