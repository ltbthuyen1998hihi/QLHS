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
    public class DanhgiasController : ControllerBase
    {
        QuanLyHieuSuatContext db = new QuanLyHieuSuatContext();

        public string auto_id()
        {

            int id;
            string autoID = "DG";
            if (db.Danhgia.Count() == 0) id = 0;
            else
            {
                var maxID = db.Danhgia.Max(x => x.Masodanhgia);
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
        [HttpGet]
        public IEnumerable<DanhGiaDTO> Index()
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc 

                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa= a.Danhhieukhoa


                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("Tatca/{idnh}")]
        public IEnumerable<DanhGiaDTO> tatca(int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Manamhoc==idnh
                         
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa


                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("Tatcabm/{idbm}/{idnh}")]
        public IEnumerable<DanhGiaDTO> bm(string idbm, int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Manamhoc == idnh && b.Mabomon==idbm

                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa


                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("khoachuadanhgia/{idnh}")]
        public IEnumerable<DanhGiaDTO> chuadg(int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Khoa == null && a.Bomon != null && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa



                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("khoadanhgia/{idnh}")]
        public IEnumerable<DanhGiaDTO> dadg(int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Khoa != null && a.Bomon != null && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("bmdanhgia/{id}/{idnh}")]
        public IEnumerable<DanhGiaDTO> bmdg(string id, int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Bomon != null && b.Mabomon == id && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,
                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("bmchuadanhgia/{id}/{idnh}")]
        public IEnumerable<DanhGiaDTO> bmchuadg(string id, int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Bomon == null && b.Mabomon == id && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("tatcabmchuadanhgia/{idnh}")]
        public IEnumerable<DanhGiaDTO> tatcabmchuadanhgia(int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         where a.Bomon == null && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.ToList();
            }
            catch
            {
                throw;
            }
        }
       
        [HttpGet("{id}")]
        public DanhGiaDTO Details(string id)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Chucdanh on b.Machucdanh equals d.Machucdanh
                         join e in db.Bomon on b.Mabomon equals e.Mabomon
                         join f in db.Khoa on e.Makhoa equals f.Makhoa
                         where a.Masodanhgia == id
                         select new DanhGiaDTO()
                         {
                             Machucdanh = d.Machucdanh,
                             Tenchucdanh = d.Tenchucdanh,
                             Tenkhoa = f.Tenkhoa,
                             Hangchucdanh = d.Hangchucdanh,
                             Tenbomon = e.Tenbomon,
                             Masodanhgia = a.Masodanhgia,
                             Bacluong= b.Bacluong,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("Vienchuc/{idvc}/{idnh}")]
        public DanhGiaDTO ctvienchuc(string idvc, int idnh)
        {
            try
            {
                var dg = from a in db.Danhgia
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Chucdanh on b.Machucdanh equals d.Machucdanh
                         join e in db.Bomon on b.Mabomon equals e.Mabomon
                         join f in db.Khoa on e.Makhoa equals f.Makhoa
                         where a.Mavienchuc ==idvc && a.Manamhoc==idnh
                         select new DanhGiaDTO()
                         {
                             Machucdanh = d.Machucdanh,
                             Tenchucdanh = d.Tenchucdanh,
                             Tenkhoa = f.Tenkhoa,
                             Hangchucdanh = d.Hangchucdanh,
                             Tenbomon = e.Tenbomon,
                             Masodanhgia = a.Masodanhgia,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Kqth = a.Kqth,
                             Daoduc = a.Daoduc,
                             Trachnhiem = a.Trachnhiem,
                             Khac = a.Khac,
                             Uudiem = a.Uudiem,
                             Nhuocdiem = a.Nhuocdiem,
                             Loai = a.Loai,
                             Ykbm = a.Ykbm,
                             Bacluong=b.Bacluong,
                             Danhhieubm = a.Danhhieubm,
                             Danhhieukhoa = a.Danhhieukhoa,

                             Bomon = a.Bomon,

                             Ykienkhoa = a.Ykienkhoa,
                             Khoa = a.Khoa,
                             Ngayvcdg = a.Ngayvcdg,
                             Ngaybmdg = a.Ngaybmdg,
                             Ngaykhoadg = a.Ngaykhoadg



                         };
                return dg.SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public int Create([FromBody] Danhgia dg)
        {


            dg.Masodanhgia = auto_id();
            db.Danhgia.Add(dg);
            try
            {
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
                return 1;

            }
            catch (DbUpdateException)
            {
                throw;
            }
        }



        [HttpPut("{id}")]
        public int Edit(Danhgia dg)
        {
            try
            {
                Danhgia dgia = db.Danhgia.Find(dg.Masodanhgia);
                dgia.Masodanhgia = dgia.Masodanhgia;
                dgia.Manamhoc = dgia.Manamhoc;
                dgia.Mavienchuc = dgia.Mavienchuc;
                dgia.Kqth = dg.Kqth;
                dgia.Daoduc = dg.Daoduc;
                dgia.Trachnhiem = dg.Trachnhiem;
                dgia.Khac = dg.Khac;
                dgia.Uudiem = dg.Uudiem;
                dgia.Nhuocdiem = dg.Nhuocdiem;
                dgia.Loai = dg.Loai;
                dgia.Ngayvcdg = dg.Ngayvcdg;
                dgia.Ykbm = dgia.Ykbm;
                dgia.Bomon = dgia.Bomon;
                dgia.Ykienkhoa = dgia.Ykienkhoa;
                dgia.Khoa = dgia.Khoa;
                db.Entry(dgia).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

      


        [HttpPut("Bomon/{id}")]
        public int EditBM(Danhgia dg)
        {
            try
            {
                Danhgia dgia = db.Danhgia.Find(dg.Masodanhgia);
                dgia.Masodanhgia = dgia.Masodanhgia;
                dgia.Manamhoc = dgia.Manamhoc;
                dgia.Mavienchuc = dgia.Mavienchuc;
                dgia.Kqth = dgia.Kqth;
                dgia.Daoduc = dgia.Daoduc;
                dgia.Trachnhiem = dgia.Trachnhiem;
                dgia.Khac = dgia.Khac;
                dgia.Uudiem = dgia.Uudiem;
                dgia.Nhuocdiem = dgia.Nhuocdiem;
                dgia.Loai = dgia.Loai;
                dgia.Ykbm = dg.Ykbm;
                dgia.Bomon = dg.Bomon;
                dgia.Danhhieubm = dg.Danhhieubm;
                dgia.Ngaybmdg = dg.Ngaybmdg;
                dgia.Ykienkhoa = dgia.Ykienkhoa;
                dgia.Khoa = dgia.Khoa;
                db.Entry(dgia).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }


        [HttpPut("Khoa/{id}")]
        public int EditKhoa(Danhgia dg)
        {
            try
            {
                Danhgia dgia = db.Danhgia.Find(dg.Masodanhgia);
                dgia.Masodanhgia = dgia.Masodanhgia;
                dgia.Manamhoc = dgia.Manamhoc;
                dgia.Mavienchuc = dgia.Mavienchuc;
                dgia.Kqth = dgia.Kqth;
                dgia.Daoduc = dgia.Daoduc;
                dgia.Trachnhiem = dgia.Trachnhiem;
                dgia.Khac = dgia.Khac;
                dgia.Uudiem = dgia.Uudiem;
                dgia.Nhuocdiem = dgia.Nhuocdiem;
                dgia.Loai = dgia.Loai;
                dgia.Ykbm = dgia.Ykbm;
                dgia.Bomon = dgia.Bomon;
                dgia.Ykienkhoa = dg.Ykienkhoa;
                dgia.Khoa = dg.Khoa;
                dgia.Danhhieukhoa = dg.Danhhieukhoa;
                dgia.Ngaykhoadg = dg.Ngaykhoadg;

                db.Entry(dgia).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }


        [HttpPut("Admin/{id}")]
        public int AdminEdit(Danhgia dg)
        {
            try
            {
                Danhgia dgia = db.Danhgia.Find(dg.Masodanhgia);
                dgia.Masodanhgia = dgia.Masodanhgia;
                dgia.Manamhoc = dg.Manamhoc;
                dgia.Mavienchuc = dgia.Mavienchuc;
                dgia.Kqth = dgia.Kqth;
                dgia.Daoduc = dgia.Daoduc;
                dgia.Trachnhiem = dgia.Trachnhiem;
                dgia.Khac = dgia.Khac;
                dgia.Uudiem = dgia.Uudiem;
                dgia.Nhuocdiem = dgia.Nhuocdiem;
                dgia.Loai = dgia.Loai;
                dgia.Ykbm = dg.Ykbm;
                dgia.Bomon = dg.Bomon;
                dgia.Ngaybmdg = dg.Ngaybmdg;
                dgia.Ykienkhoa = dg.Ykienkhoa;
                dgia.Khoa = dg.Khoa;
                dgia.Ngaykhoadg = dg.Ngaykhoadg;
                db.Entry(dgia).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }


      

        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            try
            {

                Danhgia dg = db.Danhgia.Find(id);

                if (dg != null)
                {

                    db.Danhgia.Remove(dg);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
