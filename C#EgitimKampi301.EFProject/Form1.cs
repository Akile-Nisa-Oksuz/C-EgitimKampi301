using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_EgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblGuide.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = textName.Text;
            guide.GuideSurname = textSurname.Text;
            db.TblGuide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla kaydedildi.");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber silindi!");
        }

       

        private void btnUp_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var upValue = db.TblGuide.Find(id);
            upValue.GuideName = textName.Text;
            upValue.GuideSurname = textSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme yapıldı.", "Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textId.Text);
            var values = db.TblGuide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource=values;

        }
    }
}
