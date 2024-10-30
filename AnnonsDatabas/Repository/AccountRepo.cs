using System.Data;
using System.Data.SqlClient;
using AnnonsDatabas.Entities;
using Microsoft.VisualBasic.ApplicationServices;

namespace AnnonsDatabas.Repository
{
    public class AccountRepo
    {
        public void Save(Account account)
        {
            string sql = "INSERT INTO Account (Username, UserPassword) VALUES (@Username, @UserPassword)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Username", account.Username),
                new SqlParameter("@UserPassword", account.UserPassword)
            };

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        public Account GetByUsername(string username)
        {
            string sql = "SELECT Id, Username, UserPassword FROM Account WHERE Username = @Username";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Username", username)
            };

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            if (data.Rows.Count == 0) return null;

            DataRow row = data.Rows[0];
            return new Account(
                (int)row["Id"],
                row["Username"].ToString(),
                row["UserPassword"].ToString() 
            );
        }

        public bool Register(Account account)
        {
            if (GetByUsername(account.Username) != null)
            {
                return false; 
            }
            Save(account);
            return true;
        }
    }
}
