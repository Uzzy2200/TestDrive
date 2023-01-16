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
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet ds = new DataSet();
        private readonly string _connectionString = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
 
        public Form1()
        {
            InitializeComponent();
            repoDB = new RepoDB();

        }
        private void UploadData()
        {
            //repoDB.Hent();

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
            var p = new Log() { /*Id = int.Parse(textBox1.Text)*/ Numberplate = Numberplate.Text, Opgave = Opgave.Text, KMBeforeShift = int.Parse(KMBeforeShift.Text), KMAfterShift = int.Parse(KMAfterShift.Text) };
            repoDB.Create(p);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var o = new Opdatere() { /*Id = int.Parse(textBox1.Text)*/ Numberplate = Numberplate.Text, Opgave = Opgave.Text, KMBeforeShift = int.Parse(KMBeforeShift.Text), KMAfterShift = int.Parse(KMAfterShift.Text) };

            repoDB.Update(o);
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

        private void Numberplate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}