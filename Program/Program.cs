using MaasBordroProgrami;
using System;

DosyaOku dosyaOkuma = new DosyaOku();
List<Personel> personeller = dosyaOkuma.OkunacakPersonelListesi();

if (personeller != null)
{
    foreach (var item in personeller)
    {
        Console.WriteLine($"{item.Ad} {item.Soyad} için çalışma süresini giriniz: ");
        int calismaSuresi = Convert.ToInt32((Console.ReadLine()));

        decimal anaOdeme = item.MaasHesapla(calismaSuresi);
        decimal mesaiHesapla = item.MesaiHesapla();
        decimal toplamOdeme = anaOdeme + mesaiHesapla;

        if (item.Title == "Memur")
        {
            Personel person = new Memur(item.Ad, item.Soyad, item.CalismaSuresi, (item as Memur).Derece, anaOdeme + mesaiHesapla + toplamOdeme, toplamOdeme, mesaiHesapla);

            MaasBordro bordro = new MaasBordro();
            string dosyaUrl = @"C:\Users\tapan\Desktop\Personeller";
            bordro.BordroOlustur(person, dosyaUrl);
        }
        else if (item.Title == "Yonetici")
        {
            if (item is Yonetici yonetici)
            {
                Personel person = new Yonetici(item.Ad, item.Soyad, item.CalismaSuresi, item.SaatlikUcret, yonetici.Bonus, anaOdeme + mesaiHesapla + toplamOdeme, mesaiHesapla);
                MaasBordro bordro = new MaasBordro();
                string dosyaUrl = @"C:\Users\tapan\Desktop\Personeller";
                bordro.BordroOlustur(person, dosyaUrl);
            }
            else
            {
                Console.WriteLine("Yönetici bilgisi eksik.");
            }
        }

    }

    MaasBordro bordroOku = new MaasBordro();
    bordroOku.CalismaRaporu(personeller);

    foreach (var item in personeller)
    {
        if (item.CalismaSuresi < 150 && item.CalismaSuresi > 10)
        {
            Console.WriteLine($"{item.Ad} {item.Soyad} 150 saatin altında çalışma süresine sahip. Çalışma süresi: {item.CalismaSuresi}");
        }
    }
}
else
{
    Console.WriteLine("Veri okunamadı.");
}



