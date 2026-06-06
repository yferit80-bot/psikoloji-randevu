using System;
using System.Collections.Generic;

namespace PsikologRandevu.Models;

public partial class Hastum
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string? TcNo { get; set; }

    public DateOnly? DogumTarihi { get; set; }
}
