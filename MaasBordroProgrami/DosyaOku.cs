using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaasBordroProgrami
{
    public class DosyaOku
    {
        public List<Personel> OkunacakPersonelListesi()
        {
            string dosyaYolu = @"C:\Users\tapan\Desktop\Personeller\personeller.json";
            List<Personel> personeller = null;

            using (FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonContent = reader.ReadToEnd();

                    personeller = DeserializePersonelListesi(jsonContent);
                }
            }
            return personeller;
        }

        private List<Personel> DeserializePersonelListesi(string jsonContent)
        {
            List<Personel> personeller = new List<Personel>();
            var personelList = JsonSerializer.Deserialize<JsonElement[]>(jsonContent);

            foreach (var personelElement in personelList)
            {
                string title = personelElement.GetProperty("Title").GetString();

                if (title == "Memur")
                {
                    var memur = JsonSerializer.Deserialize<Memur>(personelElement.GetRawText());
                    personeller.Add(memur);
                }
                else if (title == "Yonetici")
                {
                    var yonetici = JsonSerializer.Deserialize<Yonetici>(personelElement.GetRawText());
                    personeller.Add(yonetici);
                }
                else
                {
                    throw new InvalidOperationException("Bilinmeyen personel türü: " + title);
                }
            }
            return personeller;
        }
    }
}

