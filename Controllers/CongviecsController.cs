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
    public class CongviecsController : ControllerBase
    {
        QuanLyHieuSuatContext db = new QuanLyHieuSuatContext();




        [HttpGet]
        public IEnumerable<CongViecDTO> Index()
        {
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("danhsach/{id}")]
        public IEnumerable<CongViecDTO> ds(string id)
        {
            var nh = (from a in db.Namhoc orderby a.Manamhoc descending select a.Manamhoc).FirstOrDefault();
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         join e in db.Linhvuccongviec on d.Masolinhvuc equals e.Masolinhvuc
                         where a.Manamhoc == nh && a.Mavienchuc == id
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("congtac/{id}")]
        public IEnumerable<CongViecDTO> Congtac(string id)
        {
            var nh = (from a in db.Namhoc orderby a.Manamhoc descending select a.Manamhoc).FirstOrDefault();
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         join e in db.Linhvuccongviec on d.Masolinhvuc equals e.Masolinhvuc
                         where e.Masolinhvuc==8 && a.Manamhoc==nh && a.Mavienchuc==id
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpGet("renluyen/{id}")]
        public IEnumerable<CongViecDTO> renluyen(string id)
        {
            var nh = (from a in db.Namhoc orderby a.Manamhoc descending select a.Manamhoc).FirstOrDefault();
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         join e in db.Linhvuccongviec on d.Masolinhvuc equals e.Masolinhvuc
                         where e.Masolinhvuc == 1 && a.Manamhoc==nh && a.Mavienchuc==id
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("cvbomon/{id}")]
        public IEnumerable<CongViecDTO> bm(string id)
        {
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         where b.Mabomon == id
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        [HttpGet("{id}/{idnh}")]
        public IEnumerable<CongViecDTO> Cviec(string id, int idnh)
        {
            try
            {
                var cv = from a in db.Congviec
                         join b in db.Vienchuc on a.Mavienchuc equals b.Mavienchuc
                         join c in db.Namhoc on a.Manamhoc equals c.Manamhoc
                         join d in db.Danhmuc on a.Masodanhmuc equals d.Masodanhmuc
                         where a.Mavienchuc == id && a.Manamhoc==idnh
                         select new CongViecDTO()
                         {
                             Macongviec = a.Macongviec,
                             Manamhoc = c.Manamhoc,
                             Tennamhoc = c.Tennamhoc,
                             Mavienchuc = b.Mavienchuc,
                             Hoten = b.Hoten,
                             Masodanhmuc = a.Masodanhmuc,
                             Tendanhmuc = d.Tendanhmuc,
                             Tencongviec = a.Tencongviec,
                             Thoigianbd = a.Thoigianbd,
                             Diadiem = a.Diadiem,
                             Thoigiankt = a.Thoigiankt,
                             Filecongvec = a.Filecongvec,
                             Mucdoht = a.Mucdoht

                         };
                return cv.ToList();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpPost]
        public int Create([FromBody] Congviec cv)
        {



            db.Congviec.Add(cv);
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

        public int Edit(Congviec cv)
        {
            try
            {
                db.Entry(cv).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]

        public int Delete(int id)
        {
            try
            {

                Congviec cv = db.Congviec.Find(id);

                if (cv != null)
                {

                    db.Congviec.Remove(cv);
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
