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
    public class RepoDB
    {


        Bitmap bitmap;
        private SqlConnection _con = new SqlConnection();
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        DataTable sqlDt = new DataTable();
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet ds = new DataSet();
        private readonly string _connectionString = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public RepoDB()
        {
            
        }
        public int Create(Log log)
        {
            int result = -1;
            using (SqlConnection _con = new SqlConnection(_connectionString))
            {
                try
                { 
                sqlConn.Open();
                string sqlQuery = "INSERT INTO User (Numberplate, Opgave, KMBeforeShift, KMAfterShift) VALUES (@Numberplate, @Opgave, @KMBeforeShift, @KMAfterShift)";
                using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
                {
                    command.Parameters.AddWithValue("@Numberplate", log.Numberplate);
                    command.Parameters.AddWithValue("@Opgave", log.Opgave);
                    command.Parameters.AddWithValue("@KMBeforeShift", log.KMBeforeShift);
                    command.Parameters.AddWithValue("@KMAfterShift", log.KMAfterShift);
                    var SavedRows = command.ExecuteNonQuery();
                    result = SavedRows;
                    sqlConn.Close();
                }
                }
                catch (Exception ex)
                {
                    sqlConn.Close();
                    MessageBox.Show(ex.Message);
                }
                return result;
            }

        }
        public DataTable Read()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                string sql = "SELECT * FROM User";

                using (SqlCommand command = new SqlCommand(sql, sqlConn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        return customers;
                    }
                }
            }
        }
        public int Update(Opdatere opdatere)
        {
            int result = -1;
            string sql = @"
                        UPDATE [User]
                        SET Numberplate = @Numberplate,
                        Opgave = @Opgave,
                        KMBeforeShift = @KMBeforeShift,
                        KMAfterShift = @KMAfterShift";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                { 
                sqlConn.Open();
                using (SqlCommand command = new SqlCommand(sql, sqlConn))
                {
                    command.Parameters.AddWithValue("@Numberplate", opdatere.Numberplate);
                    command.Parameters.AddWithValue("@Opgave", opdatere.Opgave);
                    command.Parameters.AddWithValue("@KMBeforeShift", opdatere.KMBeforeShift);
                    command.Parameters.AddWithValue("@KMAfterShift", opdatere.KMAfterShift);
                    var UpdatedRows = command.ExecuteNonQuery();
                    result = UpdatedRows;
                }
                }
                catch (Exception ex)
                {
                    sqlConn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
        public void Hent()
        { 
            sqlConn.ConnectionString = _connectionString;
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT * FROM [User]";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView2.DataSource = sqlDt;
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                sqlConn.Open();

                string sql = "DELETE FROM Customers WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(sql, sqlConn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

