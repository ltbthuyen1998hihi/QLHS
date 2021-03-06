﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyHieuSuat.DTO;
using QuanLyHieuSuat.Models;

namespace QuanLyHieuSuat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VienchucsController : ControllerBase
    {
        QuanLyHieuSuatContext db = new QuanLyHieuSuatContext();
        [HttpGet("tatca/{id}")]
        public IEnumerable<VienChucDTO> Index(string id)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                      where a.Mavienchuc != id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("hesoluong/{id}")]
        public Double HSo(string id)
        {
            double hs=0;
            var bac = from a in db.Vienchuc join b in db.Chucdanh on a.Machucdanh equals b.Machucdanh where a.Mavienchuc ==id select a.Bacluong;
            var hang = from a in db.Vienchuc join b in db.Chucdanh on a.Machucdanh equals b.Machucdanh where a.Mavienchuc == id select b.Hangchucdanh;
            switch (hang.ToString())
            {
                case "I":
                    switch(bac.ToString())
                    {
                        case "1":   hs = 6.2;  break;
                        case "2":  hs = 6.56; break;
                        case "3":   hs = 6.92; break;
                        case "4":  hs = 7.28; break;
                        case "5":   hs = 7.64; break;
                        case "6":   hs = 8.0; break;


                    }
                    return hs;
                case "II":
                    switch (bac.ToString())
                    {
                        case "1":   hs = 4.4; break;
                        case "2":   hs = 4.74; break;
                        case "3":  hs = 5.08; break;
                        case "4":   hs = 5.42; break;
                        case "5":   hs = 5.76; break;
                        case "6":   hs = 6.10; break;
                        case "7":   hs = 6.44; break;
                        case "8":  hs = 6.78; break;


                    }
                    return hs;
                default:
                    switch (bac.ToString())
                    {
                        case "1":   hs = 2.34; break;
                        case "2":  hs = 2.67; break;
                        case "3":   hs = 3.0; break;
                        case "4":   hs = 3.33; break;
                        case "5":   hs = 3.66; break;
                        case "6":   hs = 3.99; break;
                        case "7":   hs = 4.32; break;
                        case "8":   hs = 4.65; break;
                        case "9":   hs = 4.98; break;


                            }
                    return hs;
            }


            
        }
        [HttpGet("thud")]
        public IEnumerable<VienChucDTO> thud()
        {
            string id = "THUD";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon==id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("cntt")]
        public IEnumerable<VienChucDTO> cntt()
        {
            string id = "CNTT";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("mtt")]
        public IEnumerable<VienChucDTO> mtt()
        {
            string id = "MTT & TT";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("httt")]
        public IEnumerable<VienChucDTO> httt()
        {
            string id = "HTTT";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("cnpm")]
        public IEnumerable<VienChucDTO> cnpm()
        {
            string id = "CNPM";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("khmt")]
        public IEnumerable<VienChucDTO> khmt()
        {
            string id = "KHMT";
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         where a.Mabomon == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Hangchucdanh = d.Hangchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }


        [HttpGet("{id}")]
        public VienChucDTO Details(string id)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         
                         where a.Mavienchuc == id
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                            Hangchucdanh=d.Hangchucdanh,
                           
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.SingleOrDefault();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("dg")]
        public IEnumerable<VienChucDTO> DG()
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Phancong on a.Mavienchuc equals e.Mavienchuc
                        
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Manamhoc= e.Manamhoc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("bomon/{id}/{idvc}")]
        public IEnumerable<VienChucDTO> VCBomon(string id, string idvc)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                        
                      
                         where a.Mabomon == id && a.Mavienchuc != idvc && a.Machucvu != "TK"
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                            
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("vcgioi/{idnh}")]
        public IEnumerable<VienChucDTO> VCgioi(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Khoa == 2 && e.Manamhoc==idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                            Masodanhgia= e.Masodanhgia,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("vcxs/{idnh}")]
        public IEnumerable<VienChucDTO> VCXS(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                        where e.Khoa == 1 && e.Manamhoc==idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Masodanhgia = e.Masodanhgia,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("vctb/{idnh}")]
        public IEnumerable<VienChucDTO> vctb(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Khoa == 3 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Masodanhgia = e.Masodanhgia,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("vcyeu/{idnh}")]
        public IEnumerable<VienChucDTO> vcyeu(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Khoa == 4 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Masodanhgia = e.Masodanhgia,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        public string auto_id()
        {

            int id;
            string autoID = "CB";
            if (db.Vienchuc.Count() == 0) id = 0;
            else
            {
                var maxID = db.Vienchuc.Max(x => x.Mavienchuc);
                id = int.Parse(maxID.Substring(3));
            }
            id++;
            switch (id.ToString().Length)
            {
                case 1:
                    autoID += "00" + id;
                    break;
                case 2:
                    autoID += "0" + id;
                    break;
                default:
                    autoID += id;
                    break;
            }
            return autoID;
        }

        [HttpPost]
        public int Themvienchuc(Vienchuc vc)
        {
            vc.Mavienchuc = auto_id();
            db.Vienchuc.Add(vc);
            db.SaveChanges();

            return 1;
        }
        [HttpPut("{id}")]

        public int Edit(Vienchuc vc)
        {
            Vienchuc vchuc = db.Vienchuc.Find(vc.Mavienchuc);

            vchuc.Mavienchuc = vchuc.Mavienchuc;
            vchuc.Mail = vchuc.Mail;
            vchuc.Matkhau = vchuc.Matkhau;

            vchuc.Mabomon = vc.Mabomon;
            vchuc.Machucdanh = vc.Machucdanh;
            vchuc.Machucvu = vc.Machucvu;
            vchuc.Hoten = vc.Hoten;
            vchuc.Sdt = vc.Sdt;
            vchuc.Ngaysinh = vc.Ngaysinh;
            vchuc.Gioitinh = vc.Gioitinh;
            vchuc.Diachi = vc.Diachi;
            vc.Ngaylamviec = vc.Ngaylamviec;
            vc.Bacluong = vc.Bacluong;

            try
            {
                db.Entry(vchuc).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("ldtt/{idnh}")]
        public IEnumerable<VienChucDTO> ldtt(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Danhhieukhoa == 1 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Masodanhgia = e.Masodanhgia,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("thcs/{idnh}")]
        public IEnumerable<VienChucDTO> thcs(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Danhhieukhoa == 2 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Masodanhgia = e.Masodanhgia,
                             Machucvu = b.Machucvu,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("tdcb/{idnh}")]
        public IEnumerable<VienChucDTO> tdcb(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Danhhieukhoa == 3 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Masodanhgia = e.Masodanhgia,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("tdtq/{idnh}")]
        public IEnumerable<VienChucDTO> tdtq(int idnh)
        {
            try
            {
                var vc = from a in db.Vienchuc
                         join b in db.Chucvu on a.Machucvu equals b.Machucvu
                         join c in db.Bomon on a.Mabomon equals c.Mabomon
                         join d in db.Chucdanh on a.Machucdanh equals d.Machucdanh
                         join e in db.Danhgia on a.Mavienchuc equals e.Mavienchuc
                         where e.Danhhieukhoa == 4 && e.Manamhoc == idnh
                         select new VienChucDTO()
                         {
                             Mavienchuc = a.Mavienchuc,
                             Mabomon = c.Mabomon,
                             Machucvu = b.Machucvu,
                             Masodanhgia = e.Masodanhgia,
                             Machucdanh = d.Machucdanh,
                             Hoten = a.Hoten,
                             Sdt = a.Sdt,
                             Ngaysinh = a.Ngaysinh,
                             Gioitinh = a.Gioitinh,
                             Diachi = a.Diachi,
                             Mail = a.Mail,
                             Matkhau = a.Matkhau,
                             Ngaylamviec = a.Ngaylamviec,
                             Tenbomon = c.Tenbomon,
                             Tenchucvu = b.Tenchucvu,
                             Tenchucdanh = d.Tenchucdanh,
                             Bacluong = a.Bacluong
                         };
                return vc.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Vienchuc vc = db.Vienchuc.Find(id);

                if (vc != null)
                {
                    
                        db.Vienchuc.Remove(vc);

                        db.SaveChanges();
                        return Ok();
                    
                }
                else
                {
                    return BadRequest();


                }
            }
            catch
            {
                throw;
            }
        }


    }
}
