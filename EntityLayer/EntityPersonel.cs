using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonel
    {
        private int PersonelId; //İlgili satırın üerine gelip ctrl+RE yapılır.
        private string ad;
        private string soyad;
        private string sehir;
        private string gorev;
        private decimal maas;

        public int PersonelId1 { get => PersonelId; set => PersonelId = value; } // Bu yapının adı kapsüllemedir. Get:Oku Set:Değer Ata.
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Gorev { get => gorev; set => gorev = value; }
        public decimal Maas { get => maas; set => maas = value; }
    }
}
