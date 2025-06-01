using Microsoft.AspNetCore.Mvc;
using SIPAS_KhaoSat.Data;
using SIPAS_KhaoSat.Models;
using SIPAS_KhaoSat.ViewModels;

namespace SIPAS_KhaoSat.Controllers
{
    public class DoiTuongKhaoSatController : Controller
    {
        private readonly SipasDbContext _context;

        public DoiTuongKhaoSatController(SipasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult PhanA()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhanA(DoiTuongKhaoSatViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.MaDanToc == 2 && !string.IsNullOrWhiteSpace(model.DanTocKhac))
                {
                    var danTocMoi = _context.DanTocs.FirstOrDefault(d => d.TenDanToc == model.DanTocKhac.Trim());
                    if (danTocMoi == null)
                    {
                        danTocMoi = new SIPAS_DanToc { TenDanToc = model.DanTocKhac.Trim() };
                        _context.DanTocs.Add(danTocMoi);
                    }
                    model.MaDanToc = danTocMoi.MaDanToc;
                }

                if (model.MaHocVan == 6 && !string.IsNullOrWhiteSpace(model.HocVanKhac))
                {
                    var hocVanMoi = _context.TrinhDoHocVans.FirstOrDefault(h => h.TenHocVan == model.HocVanKhac.Trim());
                    if (hocVanMoi == null)
                    {
                        hocVanMoi = new SIPAS_TrinhDoHocVan { TenHocVan = model.HocVanKhac.Trim() };
                        _context.TrinhDoHocVans.Add(hocVanMoi);
                    }
                    model.MaHocVan = hocVanMoi.MaHocVan;
                }

                if (model.MaNgheNghiep == 7 && !string.IsNullOrWhiteSpace(model.NgheNghiepKhac))
                {
                    var ngheNghiepMoi = _context.NgheNghieps.FirstOrDefault(n => n.TenNgheNghiep == model.NgheNghiepKhac.Trim());
                    if (ngheNghiepMoi == null)
                    {
                        ngheNghiepMoi = new SIPAS_NgheNghiep { TenNgheNghiep = model.NgheNghiepKhac.Trim() };
                        _context.NgheNghieps.Add(ngheNghiepMoi);
                    }
                    model.MaNgheNghiep = ngheNghiepMoi.MaNgheNghiep;
                }

                if (model.MaNoiSong == 7 && !string.IsNullOrWhiteSpace(model.NoiSongKhac))
                {
                    var noiSongMoi = _context.NoiSinhSongs.FirstOrDefault(n => n.TenNoiSong == model.NoiSongKhac.Trim());
                    if (noiSongMoi == null)
                    {
                        noiSongMoi = new SIPAS_NoiSinhSong { TenNoiSong = model.NoiSongKhac.Trim() };
                        _context.NoiSinhSongs.Add(noiSongMoi);
                    }
                    model.MaNoiSong = noiSongMoi.MaNoiSong;
                }

                var doiTuong = new SIPAS_DoiTuongKhaoSat
                {
                    GioiTinh = model.GioiTinh == true,
                    DoTuoi = model.DoTuoi,
                    MaDanToc = model.MaDanToc,
                    MaHocVan = model.MaHocVan,
                    MaNgheNghiep = model.MaNgheNghiep,
                    MaNoiSong = model.MaNoiSong
                };

                _context.DoiTuongKhaoSats.Add(doiTuong);
                _context.SaveChanges();

                TempData["MaDoiTuong"] = doiTuong.MaDoiTuong;
                return RedirectToAction("PhanB", "Survey");
            }

            return View(model);
        }
    }
}