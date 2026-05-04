# Psikoloji Randevu Sistemi

ASP.NET Core ile geliştirilmiş psikoloji randevu yönetim sistemi.

## Tablolar

- **Kullanicilar** - Sisteme kayıtlı tüm kullanıcılar (Hasta/Psikolog/Admin)
- **Psikologlar** - Psikolog profil bilgileri
- **Hastalar** - Hasta profil bilgileri
- **Randevular** - Randevu kayıtları

## Tablolar Arası İlişkiler (ER Diyagramı)

```mermaid
erDiagram
  Kullanicilar ||--o| Psikologlar : "sahip olur"
  Kullanicilar ||--o| Hastalar : "sahip olur"
  Hastalar ||--o{ Randevular : "alir"
  Psikologlar ||--o{ Randevular : "verir"

  Kullanicilar {
    int Id PK
    string Ad
    string Soyad
    string Email
    string Sifre
    string Rol
  }

  Psikologlar {
    int Id PK
    int KullaniciId FK
    string Uzmanlik
    string Biyografi
    decimal SeansUcreti
  }

  Hastalar {
    int Id PK
    int KullaniciId FK
    string Telefon
    date DogumTarihi
  }

  Randevular {
    int Id PK
    int HastaId FK
    int PsikologId FK
    datetime Tarih
    string Saat
    string Durum
  }
```

## Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (SSMS)
- Bootstrap
