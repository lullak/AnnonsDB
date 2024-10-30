using AnnonsDatabas.Entities;
using System.Data.SqlClient;
using System.Data;

namespace AnnonsDatabas.Repository
{
    public class CategoryRepo
    {

        public List<Category> GetList()
        {
            string sql = "SELECT Id, CategoryName FROM Category";
            DataTable data = DataContext.ExecuteQueryReturnTable(sql, new List<SqlParameter>());

            List<Category> catagories = new List<Category>();
            foreach (DataRow row in data.Rows)
            {
                catagories.Add(new Category((int)row.ItemArray[0], row.ItemArray[1].ToString()));
            }

            return catagories;
        }
    }
}
