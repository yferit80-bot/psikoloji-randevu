# Psikoloji Randevu Sistemi

ASP.NET Core ile geliştirilmiş psikoloji randevu yönetim sistemi.

## Özellikler

- Hasta ve Psikolog için ayrı giriş sistemi
- Hasta ve Psikolog için kayıt ol sayfası
- Rol bazlı navbar (Hasta/Psikolog ayrımı)
- Randevu oluşturma, onaylama ve iptal etme
- Görüşme notu ekleme ve listeleme
- Login olmadan sayfalara erişim engeli
- Mobil uyumlu tasarım (Bootstrap 5)

## Tablolar

- **Kullanicilar** - Sisteme kayıtlı tüm kullanıcılar (Hasta/Psikolog)
- **Psikologlar** - Psikolog profil bilgileri
- **Hastalar** - Hasta profil bilgileri
- **Randevular** - Randevu kayıtları
- **GorusmeNotlari** - Görüşme notları

## Teknolojiler

- ASP.NET Core 8 MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Font Awesome

## Kullanım

1. Kayıt ol sayfasından hasta veya psikolog olarak kayıt ol
2. Giriş yap
3. Hasta → Psikolog seç → Randevu oluştur
4. Psikolog → Randevuyu onayla → Görüşme notu ekle

## Kurulum

1. Projeyi klonla
2. `Update-Database` komutunu çalıştır
3. `dotnet run` ile başlat
