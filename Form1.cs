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
        Bitmap bitmap;
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet ds = new DataSet();
        private readonly string _connectionstring = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Form1()
        {
            InitializeComponent();
        }
        private void UploadData()
        {
            sqlConn.ConnectionString = _connectionstring;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT * FROM [User]";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView2.DataSource = sqlDt;
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
            sqlConn.ConnectionString = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            try
            {
                sqlConn.Open();
                sqlQuery = "insert into [User] (Numberplate, Opgave, KMBeforeShift, KMAfterShift)" + "values('," + Numberplate.Text + "', '" + Opgave.Text + "', '" + KMBeforeShift.Text + "', '" + KMAfterShift.Text + "')";
                sqlCmd = new SqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UploadData();
                sqlConn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionstring))
                {
                    DialogResult Confirm;
                    try
                    {
                        Confirm = MessageBox.Show("Confirm if u want to Update", "TestDrive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Confirm == DialogResult.Yes)
                        {
                            MessageBox.Show("Data opdateret");
                        }
                        if (Confirm == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        string sqlText = @"
                        UPDATE [User]
                        SET Numberplate = @Numberplate,
                        Opgave = @Opgave,
                        KMBeforeShift = @KMBeforeShift,
                        KMAfterShift = @KMAfterShift";
                        sqlCon.Open();
                        SqlCommand sqlUpdate = new SqlCommand(sqlText, sqlCon);
                        sqlCmd.Connection = sqlCon;
                        sqlUpdate.CommandType = CommandType.Text;
                        sqlUpdate.Parameters.AddWithValue("@Numberplate", Numberplate.Text);
                        sqlUpdate.Parameters.AddWithValue("@Opgave", Opgave.Text);
                        sqlUpdate.Parameters.AddWithValue("@KMBeforeShift", KMBeforeShift.Text);
                        sqlUpdate.Parameters.AddWithValue("@KMAfterShift", KMAfterShift.Text); 
                        sqlUpdate.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                }
                UploadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
