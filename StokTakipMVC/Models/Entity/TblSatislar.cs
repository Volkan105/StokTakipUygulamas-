//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipMVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSatislar
    {
        public int Id { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Personel { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual TblMusteri TblMusteri { get; set; }
        public virtual TblPersonel TblPersonel { get; set; }
        public virtual TblUrunler TblUrunler { get; set; }
    }
}
