using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource= PerList;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Maas = decimal.Parse(TxtMaas.Text);
            ent.Gorev = TxtGorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.PersonelId1 = Convert.ToInt32(TxtID.Text);
            LogicPersonel.LLPersonelSil(ent.PersonelId1);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.PersonelId1=Convert.ToInt32(TxtID.Text);
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Gorev = TxtGorev.Text;
            ent.Maas=decimal.Parse(TxtMaas.Text);
            LogicPersonel.LLPersonelGuncelle(ent);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtGorev.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtMaas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
