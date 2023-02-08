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
        private SqlConnection _con = new SqlConnection();
        private readonly string _connectionString = @"Server=tcp:drivingserver.database.windows.net,1433;Initial Catalog=DriverDB;Persist Security Info=False;User ID=Usama;Password=Ab123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        DataTable sqlDt = new DataTable();
        public RepoDB()
        {

        }
        public int Create(Log log)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO [User] (Numberplate, Opgave, KMBeforeShift, KMAfterShift) VALUES (@Numberplate, @Opgave, @KMBeforeShift, @KMAfterShift)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Numberplate", log.Numberplate);
                        command.Parameters.AddWithValue("@Opgave", log.Opgave);
                        command.Parameters.AddWithValue("@KMBeforeShift", log.KMBeforeShift);
                        command.Parameters.AddWithValue("@KMAfterShift", log.KMAfterShift);
                        var SavedRows = command.ExecuteNonQuery();
                        result = SavedRows;
                        connection.Close();   
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
            
        }
        //public DataTable Read()
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        string sql = "SELECT * FROM User";

        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                DataTable customers = new DataTable();
        //                adapter.Fill(customers);
        //                return customers;
        //            }
        //        }
        //    }
        //}
        public int Update(Opdatere opdatere)
        {
            
            int result = -1;
            
            string sql = @"
                        UPDATE [User]
                        SET Numberplate = @Numberplate,
                        Opgave = @Opgave,
                        KMBeforeShift = @KMBeforeShift,
                        KMAfterShift = @KMAfterShift WHERE CarId = "+ opdatere.Id;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
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
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
        public DataTable Hent()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlSelect = "SELECT * FROM [User]";
                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    var poster = command.ExecuteReader();
                    table.Load(poster);
                    poster.Close();
                    connection.Close();
                }
            }
            return table;
        }
        public void Delete(Deletee deletee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM [User] WHERE CarId = @CarId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CarId", deletee.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public int CreateDriver(DriverLog driverlog)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO [Driver] (NAME, CPRNR, TLF) VALUES (@NAME, @CPRNR, @TLF)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NAME", driverlog.Name);
                        command.Parameters.AddWithValue("@CPRNR", driverlog.CPRNR);
                        command.Parameters.AddWithValue("@TLF", driverlog.TLF);
                        var SavedRows = command.ExecuteNonQuery();
                        result = SavedRows;
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
        }
        public DataTable HentDriver()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlSelect = "SELECT * FROM [Driver]";
                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    var poster = command.ExecuteReader();
                    table.Load(poster);
                    poster.Close();
                    connection.Close();
                }
            }
            return table;
        }
        public int UpdateDriver(OpdatereDriver opdateredriver)
        {
            int result = -1;
            string sql = @"
                        UPDATE [Driver]
                        SET Name = @Name,
                        CPRNR = @CPRNR,
                        TLF = @TLF WHERE DriverID = " + opdateredriver.DriverId;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NAME", opdateredriver.Name);
                        command.Parameters.AddWithValue("@CPRNR", opdateredriver.CPRNR);
                        command.Parameters.AddWithValue("@TLF", opdateredriver.TLF);

                        var UpdatedRowss = command.ExecuteNonQuery();
                        result = UpdatedRowss;
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
        public void DeleteDriver(DeleteDriver deletedriver)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM [Driver] WHERE DriverID = @DriverID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", deletedriver.DriverId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable SearchLog(SearchFunction searchfunction)
        {
             DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlSelect = "SELECT * FROM [User] where Numberplate='" + searchfunction.Numberplate + "'"; 
                using (SqlCommand command = new SqlCommand(sqlSelect, connection))
                {
                    var poster = command.ExecuteReader();
                    table.Load(poster);
                    poster.Close();
                    connection.Close();
                }
            }
            return table;
        }

    }
}