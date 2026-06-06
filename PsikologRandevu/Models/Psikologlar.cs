using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class Psikologlar
{
    public int Id { get; set; }

    public int KullaniciId { get; set; }

    public string Uzmanlik { get; set; } = null!;

    public string Biyografi { get; set; } = null!;

    public decimal SeansUcreti { get; set; }

    public virtual ICollection<GorusmeNotlari> GorusmeNotlaris { get; set; } = new List<GorusmeNotlari>();

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual ICollection<Randevular> Randevulars { get; set; } = new List<Randevular>();
}
