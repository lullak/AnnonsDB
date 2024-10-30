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
                row["UserPassword"].ToString() // Use UserPassword instead of UserPassword
            );
        }

        public bool Register(Account account)
        {
            // Check if the username already exists
            if (GetByUsername(account.Username) != null)
            {
                return false; // Username already taken
            }

            // Save the account
            Save(account);
            return true; // Registration successful
        }

        public List<Account> GetList()
        {
            string sql = "SELECT Id, Username, UserPassword FROM Account";
            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Account> accounts = new List<Account>();
            foreach (DataRow row in data.Rows)
            {
                accounts.Add(new Account(
                    (int)row["Id"],
                    row["Username"].ToString(),
                    row["UserPassword"].ToString() // Use UserPassword instead of UserPassword
                ));
            }

            return accounts;
        }
    }
}
