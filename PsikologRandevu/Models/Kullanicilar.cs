using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class Kullanicilar
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Hastalar> Hastalars { get; set; } = new List<Hastalar>();

    public virtual ICollection<Psikologlar> Psikologlars { get; set; } = new List<Psikologlar>();
}
