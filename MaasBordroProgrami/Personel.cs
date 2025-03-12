using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaasBordroProgrami
{
    public abstract class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Title { get; set; }

        public decimal SaatlikUcret { get; set; }

        public int CalismaSuresi { get; set; }
        public decimal ToplamOdeme { get; set; }
        public decimal MesaiUcreti { get; set; }


        public abstract decimal MaasHesapla(int saatlikUcret);

        public Personel(string ad, string soyad, string title, int calismaSuresi, decimal saatlikUcret, decimal toplamOdeme, decimal mesaiUcreti)
        {
            Ad = ad;
            Soyad = soyad;
            Title = title;
            CalismaSuresi = calismaSuresi;
            SaatlikUcret = saatlikUcret;
            ToplamOdeme = toplamOdeme;
            MesaiUcreti = mesaiUcreti;
        }

        public decimal MesaiHesapla()
        {
            if (CalismaSuresi > 180)
            {
                int fazlaMesaiSuresi = CalismaSuresi - 180;

                return fazlaMesaiSuresi * SaatlikUcret * 1.5m;
            }
            return 0;
        }
    }
}
