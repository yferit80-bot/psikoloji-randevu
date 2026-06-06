using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class Randevular
{
    public int Id { get; set; }

    public int HastaId { get; set; }

    public int PsikologId { get; set; }

    public DateTime Tarih { get; set; }

    public string Saat { get; set; } = null!;

    public string Durum { get; set; } = null!;

    public virtual ICollection<GorusmeNotlari> GorusmeNotlaris { get; set; } = new List<GorusmeNotlari>();

    public virtual Hastalar Hasta { get; set; } = null!;

    public virtual Psikologlar Psikolog { get; set; } = null!;
}
