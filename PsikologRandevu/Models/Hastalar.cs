using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class Hastalar
{
    public int Id { get; set; }

    public int KullaniciId { get; set; }

    public string Telefon { get; set; } = null!;

    public DateTime DogumTarihi { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual ICollection<Randevular> Randevulars { get; set; } = new List<Randevular>();
}
