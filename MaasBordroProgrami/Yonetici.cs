using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami
{
    public class Yonetici : Personel
    {
        public decimal Bonus { get; set; }

        public Yonetici(string ad, string soyad, int calismaSuresi, decimal saatlikUcret, decimal bonus, decimal toplamOdeme, decimal mesaiUcreti)
           : base(ad, soyad, "Yonetici", calismaSuresi, saatlikUcret, toplamOdeme, mesaiUcreti)
        {
            Bonus = bonus;
        }

        public override decimal MaasHesapla(int calismaSuresi)
        {
            if (SaatlikUcret < 500)
            {
                throw new InvalidOperationException("Yönetici saatlik ücret 500 altında olamaz.");
            }
            else
            {
                decimal yapilacakOdeme = (SaatlikUcret * CalismaSuresi) + Bonus;

                return yapilacakOdeme;
            }
        }
    }
}
