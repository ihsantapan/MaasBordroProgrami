using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaasBordroProgrami
{
    public class MaasBordro
    {
        public void BordroOlustur(Personel personel, string dosyaUrl)
        {
            try
            {
                string personelKlasoru = Path.Combine(dosyaUrl, $"{personel.Ad}_{personel.Soyad}");

                Directory.CreateDirectory(personelKlasoru);

                string dosyaYolu = Path.Combine(personelKlasoru, "bordro.json");

                decimal anaOdeme = personel.MaasHesapla(personel.CalismaSuresi);
                decimal mesaiOdeme = personel.MesaiHesapla();
                decimal toplamOdeme = anaOdeme + mesaiOdeme;

                object bordro = null;

                if (personel.Title == "Memur")
                {
                    bordro = new
                    {
                        MaasBordro = DateTime.Now.ToString("MMMM,yyyy"),
                        PersonelIsmi = $"{personel.Ad} {personel.Soyad}",
                        CalismaSaati = personel.CalismaSuresi,
                        AnaOdeme = anaOdeme,
                        Mesai = mesaiOdeme,
                        ToplamOdeme = toplamOdeme
                    };
                }
                else if (personel.Title == "Yonetici")
                {
                    bordro = new
                    {
                        MaasBordro = DateTime.Now.ToString("MMMM,yyyy"),
                        PersonelIsmi = $"{personel.Ad} {personel.Soyad}",
                        CalismaSaati = personel.CalismaSuresi,
                        AnaOdeme = anaOdeme,
                        Bonus = ((Yonetici)personel).Bonus,
                        ToplamOdeme = toplamOdeme
                    };
                }

                string json = JsonSerializer.Serialize(bordro, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });

                using FileStream stream = new FileStream(dosyaYolu, FileMode.Create, FileAccess.Write);
                using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write(json);

                Console.WriteLine($"Bordro başarıyla oluşturuldu: {dosyaYolu}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bordro oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public void CalismaRaporu(List<Personel> personeller)
        {
            var azCalisanlar = personeller.Where(p => p.CalismaSuresi < 10);

            if (azCalisanlar != null)
            {
                Console.WriteLine("\n10 Saatten Az Çalışan Personeller:");
                foreach (var item in azCalisanlar)
                {
                    if (item.CalismaSuresi < 150)
                    {
                        Console.WriteLine($"{item.Ad} {item.Soyad} -  Çalışma Saati: {item.CalismaSuresi}");
                    }
                }
            }

        }
    }
}

