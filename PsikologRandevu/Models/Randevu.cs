namespace PsikologRandevu.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int HastaId { get; set; }
        public int PsikologId { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public string Durum { get; set; }
        public Hasta Hasta { get; set; }
        public Psikolog Psikolog { get; set; }
    }
}