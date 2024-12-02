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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
    

        private void Listbtn_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(x=> new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            combGuide.DisplayMember = "FullName";
            combGuide.ValueMember = "GuideId";
            combGuide.DataSource = values;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.LocationCapacity = byte.Parse(downMax.Value.ToString());
            location.LocationCity=txtCity.Text;
            location.LocationCountry=txtCountry.Text;
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.DayNight=txtSunMoon.Text;
            location.GuideId = int.Parse(combGuide.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletValue = db.TblLocation.Find(id);
            db.TblLocation.Remove(deletValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi yapıldı!");
        }

        private void Upbtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var upValue = db.TblLocation.Find(id);
            upValue.LocationCapacity = byte.Parse(downMax.Value.ToString());
            upValue.LocationCity = txtCity.Text;
            upValue.LocationCountry = txtCountry.Text;
            upValue.LocationPrice = decimal.Parse(txtPrice.Text);
            upValue.DayNight = txtSunMoon.Text;
            upValue.GuideId = int.Parse(combGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi başarılı");

        }
    }
}
