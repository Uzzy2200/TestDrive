using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDrive
{
    public partial class Form2 : Form
    {
        RepoDB repoDB;
        public Form2()
        {
            InitializeComponent();
            repoDB = new RepoDB();
            UploadDataa();
        }
        private void UploadDataa()
        {
            dataGridView1.DataSource = repoDB.HentDriver();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
         this.Hide();
         Form1 f1 = new Form1();
         f1.ShowDialog();   
        }
        private void AddDriver_Click(object sender, EventArgs e)
        {
            DialogResult iCreate;
            try
            {
                iCreate = MessageBox.Show("Confirm if u want to create driver", "Driver Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iCreate == DialogResult.Yes)
                {
                    var d = new DriverLog() { Name = Name.Text, CPRNR = CPRNR.Text, TLF = TLF.Text };
                    repoDB.CreateDriver(d);
                    UploadDataa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
            }
        }
        private void UpdateDriver_Click(object sender, EventArgs e)
        {
            DialogResult iUpdate;
            try
            {
                iUpdate = MessageBox.Show("Confirm if u want to Update driver", "Driver Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iUpdate == DialogResult.Yes)
                {
                    var u = new OpdatereDriver() { Name = Name.Text, CPRNR = CPRNR.Text, TLF = TLF.Text, DriverId = int.Parse(DriverID.Text) };
                    repoDB.UpdateDriver(u);
                    UploadDataa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DriverID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                CPRNR.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                TLF.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteDriver_Click(object sender, EventArgs e)
        {
            DialogResult iDelete;
            try
            {
                iDelete = MessageBox.Show("Confirm if u want to delete driver", "Driver Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iDelete == DialogResult.Yes)
                {
                    var l = new DeleteDriver() { DriverId = int.Parse(DriverID.Text), Name = Name.Text, CPRNR = CPRNR.Text, TLF = TLF.Text };
                    repoDB.DeleteDriver(l);
                    UploadDataa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
            }
            UploadDataa();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel4.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}