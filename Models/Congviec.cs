﻿using System;
using System.Collections.Generic;

namespace QuanLyHieuSuat.Models
{
    public partial class Congviec
    {
        public int Macongviec { get; set; }
        public int Manamhoc { get; set; }
        public string Mavienchuc { get; set; }
        public int Masodanhmuc { get; set; }
        public string Tencongviec { get; set; }
       
        public string Diadiem { get; set; }
        public DateTime? Thoigianbd { get; set; }
        public DateTime? Thoigiankt { get; set; }
        public string Filecongvec { get; set; }

        public int? Mucdoht { get; set; }

        public virtual Namhoc ManamhocNavigation { get; set; }
        public virtual Danhmuc MasodanhmucNavigation { get; set; }
        public virtual Vienchuc MavienchucNavigation { get; set; }
    }
}
