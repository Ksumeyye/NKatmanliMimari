using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Security.Cryptography.X509Certificates;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntityPersonel p)
        {
            if(p.Ad!="" && p.Soyad !="" && p.Maas>=17000 && p.Ad.Length>=3)
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1; //Hiçbir şey yapma, ekleme işlemini gerçekleştirmeden çıkış işlemi yap.
            }
            
        }
        public static bool LLPersonelSil(int per)
        {
            if(per>=1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }
        public static bool LLPersonelGuncelle(EntityPersonel ent)
        {
            if(ent.Ad.Length>=3 && ent.Ad!="" && ent.Maas>=17000)
            {
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
    }
}
