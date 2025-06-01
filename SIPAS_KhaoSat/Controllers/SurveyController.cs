using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using SIPAS_KhaoSat.Data;
using SIPAS_KhaoSat.Models;

namespace SIPAS_KhaoSat.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SipasDbContext _context;

        public SurveyController(SipasDbContext context)
        {
            _context = context;
        }

        public IActionResult PhanB()
        {
            // Truy vấn câu hỏi thuộc nhóm chỉ số 2 (Phần B)
            var cauHoiPhanB = _context.CauHois
                .Where(c => c.SuDung && c.MaNhom == 2)
                .ToList();

            // Lấy danh sách MaNhomLuaChon từ các câu hỏi
            var nhomLuaChonIds = cauHoiPhanB
                .Where(c => c.MaNhomLuaChon.HasValue)
                .Select(c => c.MaNhomLuaChon.Value)
                .Distinct()
                .ToList();

            // Truy vấn các lựa chọn thuộc các nhóm lựa chọn
            var luaChons = _context.LuaChons
                .Where(l => l.MaNhomLuaChon.HasValue && nhomLuaChonIds.Contains(l.MaNhomLuaChon.Value))
                .ToList();

            // Gán danh sách lựa chọn vào ViewBag
            ViewBag.LuaChons = luaChons;

            // Trả về view với danh sách câu hỏi
            return View("PhanB", cauHoiPhanB);
        }

        [HttpPost]
        public IActionResult PhanB(IFormCollection form)
        {
            long maDoiTuong;

            // Kiểm tra TempData chứa MaDoiTuong
            if (TempData["MaDoiTuong"] != null)
            {
                maDoiTuong = Convert.ToInt64(TempData["MaDoiTuong"]);
                TempData.Keep("MaDoiTuong");
            }
            else
            {
                return RedirectToAction("PhanA", "DoiTuongKhaoSat");
            }

            // Xử lý dữ liệu gửi từ form
            foreach (var key in form.Keys)
            {
                if (key.StartsWith("cauhoi_") && int.TryParse(key.Replace("cauhoi_", ""), out int maCauHoi))
                {
                    if (byte.TryParse(form[key], out byte maLuaChon))
                    {
                        var cauHoi = _context.CauHois.FirstOrDefault(c => c.MaCauHoi == maCauHoi);
                        var luaChon = _context.LuaChons.FirstOrDefault(l => l.MaLuaChon == maLuaChon);
                        if (cauHoi == null || luaChon == null)
                        {
                            ModelState.AddModelError("", $"Câu hỏi {maCauHoi} hoặc lựa chọn {maLuaChon} không hợp lệ.");
                            continue;
                        }

                        var ketQua = new SIPAS_KetQua
                        {
                            MaDoiTuong = maDoiTuong,
                            MaCauHoi = maCauHoi,
                            MaLuaChon = maLuaChon,
                            LoaiThangDo = cauHoi.LoaiThangDo,
                            Diem = (short?)luaChon.Diem,
                            MaDapAn = null
                        };
                        _context.KetQuas.Add(ketQua);
                    }
                }
            }

            try
            {
                _context.SaveChanges();
                return RedirectToAction("ThankYou");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Đã xảy ra lỗi khi lưu dữ liệu: {ex.Message}");
                var cauHoiPhanB = _context.CauHois
                    .Where(c => c.SuDung && c.MaNhom == 2)
                    .ToList();
                var nhomLuaChonIds = cauHoiPhanB
                    .Where(c => c.MaNhomLuaChon.HasValue)
                    .Select(c => c.MaNhomLuaChon.Value)
                    .Distinct()
                    .ToList();
                var luaChons = _context.LuaChons
                    .Where(l => l.MaNhomLuaChon.HasValue && nhomLuaChonIds.Contains(l.MaNhomLuaChon.Value))
                    .ToList();
                ViewBag.LuaChons = luaChons;
                return View("PhanB", cauHoiPhanB);
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}