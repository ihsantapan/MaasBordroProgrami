using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaasBordroProgrami
{
    public class Memur : Personel
    {
        public int Derece { get; set; }
        public Memur(string ad, string soyad, int calismaSuresi, int derece, decimal saatlikUcret, decimal toplamOdeme, decimal mesaiUcreti)
         : base(ad, soyad, "Memur", calismaSuresi, saatlikUcret, toplamOdeme, mesaiUcreti)
        {
            Derece = derece;
            SaatlikUcret = 500 * Derece;
        }

        public override decimal MaasHesapla(int calismaSuresi)
        {
            decimal yapilacakOdeme;

            if (CalismaSuresi <= 180)
            {
                yapilacakOdeme = calismaSuresi * SaatlikUcret;
                return yapilacakOdeme;
            }
            else
            {
                decimal mesaiUcreti = MesaiHesapla();
                decimal odeme = calismaSuresi * 180;
                decimal toplamOdeme = mesaiUcreti + odeme;
                return toplamOdeme;
            }
           
        }
    }
}