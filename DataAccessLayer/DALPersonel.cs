using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer; //DAL EntityLayer departmanını ekledim.
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace DataAccessLayer
{
     public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi() //Personel Listesi Methodun İsmidir.
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select*from TblBilgi",Baglanti.bgl);
            if(komut1.Connection.State!=ConnectionState.Open)//Eğer ki benim bağlantım açık değilse,
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.PersonelId1 = int.Parse(dr["PersonelID"].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Gorev = dr["Gorev"].ToString();
                ent.Maas = decimal.Parse(dr["Maas"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2=new SqlCommand("insert into TblBilgi (Ad,Soyad,Gorev,Sehir,Maas) Values (@P1,@P2,@P3,@P4,@P5)",Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)//Eğer ki benim bağlantım açık değilse,
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Ad);
            komut2.Parameters.AddWithValue("@P2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery();

        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblBilgi where ID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)//Eğer ki benim bağlantım açık değilse,
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1",p);
            return komut3.ExecuteNonQuery() >0; // >0 eğerki şu şartları sağlaya değer varsa boolu 1 döndür yani sil 
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblBilgi Set Ad=@P1,Soyad=@P2,Maas=@P3,Sehir=@P4,Gorev=@P5 Where PersonelID=@P6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)//Eğer ki benim bağlantım açık değilse,
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Ad);
            komut4.Parameters.AddWithValue("@P2", ent.Soyad);
            komut4.Parameters.AddWithValue("@P3", ent.Sehir);
            komut4.Parameters.AddWithValue("@P4", ent.Gorev);
            komut4.Parameters.AddWithValue("@P5", ent.Maas);
            komut4.Parameters.AddWithValue("@P6", ent.PersonelId1);
            return komut4.ExecuteNonQuery() >0; //> 0 eğerki şu şartları sağlaya değer varsa boolu 1 döndür yani güncelle
        }
    }
}
