using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class GorusmeNotlari
{
    public int Id { get; set; }

    public int RandevuId { get; set; }

    public int PsikologId { get; set; }

    public string Not { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public virtual Psikologlar Psikolog { get; set; } = null!;

    public virtual Randevular Randevu { get; set; } = null!;
}
