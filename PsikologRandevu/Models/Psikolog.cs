namespace PsikologRandevu.Models
{
    public class Psikolog
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Uzmanlik { get; set; }
        public string Biyografi { get; set; }
        public decimal SeansUcreti { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}