using System.Data;
using System.Data.SqlClient;

namespace AnnonsDatabas.Repository
{
    public class DataContext
    {
        private static readonly string _connString = "Data Source=LULLAK\\MSSQLSERVER01;Initial Catalog=AdDB;Integrated Security=SSPI;TrustServerCertificate=True;";
        //localhost på laptopen
        public static DataTable ExecuteQueryReturnTable(string sql, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static void ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}
