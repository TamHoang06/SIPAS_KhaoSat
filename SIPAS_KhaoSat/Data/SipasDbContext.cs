using Microsoft.EntityFrameworkCore;
using SIPAS_KhaoSat.Models;

namespace SIPAS_KhaoSat.Data
{
    public class SipasDbContext : DbContext
    {
        public SipasDbContext(DbContextOptions<SipasDbContext> options) : base(options)
        {
        }

        public DbSet<SIPAS_CauHoi> CauHois { get; set; }
        public DbSet<SIPAS_DapAn> DapAns { get; set; }
        public DbSet<SIPAS_DapAn_YKienKhac> DapAnYKienKhacs { get; set; }
        public DbSet<SIPAS_DoiTuongKhaoSat> DoiTuongKhaoSats { get; set; }
        public DbSet<SIPAS_DotKhaoSat> DotKhaoSats { get; set; }
        public DbSet<SIPAS_DotKhaoSat_CauHoi> DotKhaoSatCauHois { get; set; }
        public DbSet<SIPAS_KetQua> KetQuas { get; set; }
        public DbSet<SIPAS_KetQuaTongHop> KetQuaTongHops { get; set; }
        public DbSet<SIPAS_LuaChon> LuaChons { get; set; }
        public DbSet<SIPAS_NhomChiSo> NhomChiSos { get; set; }
        public DbSet<SIPAS_NhomLuaChon> NhomLuaChons { get; set; }
        public DbSet<SIPAS_DoTuoi> DoTuois { get; set; }
        public DbSet<SIPAS_DanToc> DanTocs { get; set; }
        public DbSet<SIPAS_TrinhDoHocVan> TrinhDoHocVans { get; set; }
        public DbSet<SIPAS_NgheNghiep> NgheNghieps { get; set; }
        public DbSet<SIPAS_NoiSinhSong> NoiSinhSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SIPAS_DapAn_YKienKhac>()
                .HasOne(y => y.DapAn)
                .WithOne(d => d.YKienKhacNoiDung)
                .HasForeignKey<SIPAS_DapAn_YKienKhac>(y => y.MaDapAn);

            modelBuilder.Entity<SIPAS_DotKhaoSat_CauHoi>()
                .HasKey(dc => new { dc.MaDot, dc.MaCauHoi });

            modelBuilder.Entity<SIPAS_KetQua>()
                .HasKey(k => k.MaDoiTuong);
        }
    }
}
