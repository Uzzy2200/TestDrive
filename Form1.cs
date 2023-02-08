using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestDrive
{
    public partial class Form1 : Form
    {
        RepoDB repoDB;
        Bitmap bitmap;
        DataTable sqlDt = new DataTable();
        //private readonly string _connectionString = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        public Form1()
        {
            InitializeComponent();
            repoDB = new RepoDB();
            UploadData();
        }
        private void UploadData()
        {
            //repoDB.Hent();
            dataGridView2.DataSource = repoDB.Hent();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Confirm if u want to exit", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel4.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                }
                ///txtSearch.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView2.Height;
                dataGridView2.Height = dataGridView2.RowCount * dataGridView2.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView2.Width, dataGridView2.Height);
                dataGridView2.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView2.Height = Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UploadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult iCreate;
            try
            {
                iCreate = MessageBox.Show("Confirm if u want to create log", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iCreate == DialogResult.Yes)
                {
                    var p = new Log() { Numberplate = Numberplate.Text, Opgave = Opgave.Text, KMBeforeShift = int.Parse(KMBeforeShift.Text), KMAfterShift = int.Parse(KMAfterShift.Text) };
                    repoDB.Create(p);
                    UploadData();
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
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iUpdate;
            try
            {
                iUpdate = MessageBox.Show("Confirm if u want to Update log", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iUpdate == DialogResult.Yes)
                {
                    var o = new Opdatere() { Numberplate = Numberplate.Text, Opgave = Opgave.Text, KMBeforeShift = int.Parse(KMBeforeShift.Text), KMAfterShift = int.Parse(KMAfterShift.Text), Id = int.Parse(CarId.Text) };
                    repoDB.Update(o);
                    UploadData();
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
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CarId.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                Numberplate.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                Opgave.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                KMBeforeShift.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                KMAfterShift.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult iDelete;
            try
            {
                iDelete = MessageBox.Show("Confirm if u want to delete log", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iDelete == DialogResult.Yes)
                {
                    var d = new Deletee() { Id = int.Parse(CarId.Text) ,Numberplate = Numberplate.Text, Opgave = Opgave.Text, KMBeforeShift = int.Parse(KMBeforeShift.Text), KMAfterShift = int.Parse(KMAfterShift.Text) };
                    repoDB.Delete(d);
                    UploadData();
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
            UploadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView2.DataSource = repoDB.SearchLog();
            var s = new SearchFunction() { Numberplate = Numberplate.Text };
            repoDB.SearchLog(s);
            SearchData();
            //repoDB.SearchLog();
            //try
            //{
            //    DataView dv = sqlDt.DefaultView;
            //    dv.RowFilter = string.Format("Numberplate like '%{0}%'", txtSearch.Text);
            //    dataGridView2.DataSource = dv.ToTable();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    string searchTerm = txtSearch.Text;

            //    using (var context = new DriverDB())
            //    {
            //        var results = context.YourTable.Where(x => x.Name.Contains(searchTerm)).ToList();

            //        dataGridView2.DataSource = results;
            //    }
            //}
        }
        private void SearchData()
        {
            
            dataGridView2.DataSource = repoDB.SearchLog();
        }
    }
}