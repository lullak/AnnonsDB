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
            string sql = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";

            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Username", account.Username),
            new SqlParameter("@PasswordHash", account.UserPassword)
        };

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        public Account GetByUsername(string username)
        {
            string sql = "SELECT Id, Username, PasswordHash FROM Users WHERE Username = @Username";
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

        public List<Account> GetList()
        {
            string sql = "SELECT Id, Username, PasswordHash FROM Users";
            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Account> accounts = new List<Account>();
            foreach (DataRow row in data.Rows)
            {
                accounts.Add(new Account(
                    (int)row["Id"],
                    row["Username"].ToString(),
                    row["UserPassword"].ToString()
                ));
            }

            return accounts;
        }
    }
}
