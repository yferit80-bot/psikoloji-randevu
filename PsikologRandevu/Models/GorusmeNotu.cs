namespace PsikologRandevu.Models
{
    public class GorusmeNotu
    {
        public int Id { get; set; }
        public int RandevuId { get; set; }
        public int PsikologId { get; set; }
        public string Not { get; set; }
        public DateTime Tarih { get; set; }
        public Randevu Randevu { get; set; }
        public Psikolog Psikolog { get; set; }
    }
}