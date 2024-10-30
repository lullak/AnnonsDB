using AnnonsDatabas.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AnnonsDatabas.Repository
{
    public class AdvertisementRepo
    {
        public void Save(Advertisement advertisement)
        {
            string sql = "INSERT INTO Advertisements (Title, AdDescription, Price, CategoryId, CreatedBy) " +
                         "VALUES (@Title, @Description, @Price, @CategoryId, @CreatedBy)";

            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Title", advertisement.Title),
            new SqlParameter("@AdDescription", advertisement.AdDescription),
            new SqlParameter("@Price", advertisement.Price),
            new SqlParameter("@CategoryId", advertisement.CategoryId),
            new SqlParameter("@CreatedBy", advertisement.CreatedBy)
        };

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        public Advertisement GetById(int adId)
        {
            string sql = "SELECT Id, Title, AdDescription, Price, CategoryId, CreatedBy, CreatedDate FROM Advertisements WHERE Id = @AdId";
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@AdId", adId)
        };

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            if (data.Rows.Count == 0) return null;

            DataRow row = data.Rows[0];
            return new Advertisement(
                (int)row["Id"],
                row["Title"].ToString(),
                row["AdDescription"].ToString(),
                (decimal)row["Price"],
                (int)row["CategoryId"],
                (int)row["CreatedBy"],
                Convert.ToDateTime(row["CreatedDate"])
            );
        }

        public List<Advertisement> GetList(string sortBy = "CreatedDate", int? categoryId = null)
        {
            string sql = "SELECT Id, Title, AdDescription, Price, CategoryId, CreatedBy, CreatedDate FROM Advertisement";

            // Only add WHERE clause if categoryId is specified
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (categoryId.HasValue)
            {
                sql += " WHERE CategoryId = @CategoryId";
                parameters.Add(new SqlParameter("@CategoryId", categoryId.Value));
            }

            // Add ORDER BY based on sortBy parameter
            switch (sortBy)
            {
                case "Price":
                    sql += " ORDER BY Price";
                    break;
                case "CreatedDate":
                default:
                    sql += " ORDER BY CreatedDate";
                    break;
            }

            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            List<Advertisement> advertisements = new List<Advertisement>();
            foreach (DataRow row in data.Rows)
            {
                advertisements.Add(new Advertisement(
                    (int)row["Id"],
                    row["Title"].ToString(),
                    row["AdDescription"].ToString(),
                    (decimal)row["Price"],
                    (int)row["CategoryId"],
                    (int)row["CreatedBy"],
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }

            return advertisements;
        }

        public List<Advertisement> SearchAdvertisements(string title, int? categoryId = null)
        {
            // Build the base SQL query
            string sql = "SELECT Id, Title, AdDescription, Price, CategoryId, CreatedBy, CreatedDate FROM Advertisement WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // If a title is provided, add a condition for it
            if (!string.IsNullOrEmpty(title))
            {
                sql += " AND Title LIKE @Title";
                parameters.Add(new SqlParameter("@Title", "%" + title + "%")); // Using LIKE for partial matches
            }

            // If a categoryId is provided, add a condition for it
            if (categoryId.HasValue)
            {
                sql += " AND CategoryId = @CategoryId";
                parameters.Add(new SqlParameter("@CategoryId", categoryId.Value));
            }

            // Execute the query
            DataTable data = DataContext.ExecuteQueryReturnTable(sql, parameters);

            List<Advertisement> advertisements = new List<Advertisement>();
            foreach (DataRow row in data.Rows)
            {
                advertisements.Add(new Advertisement(
                    (int)row["Id"],
                    row["Title"].ToString(),
                    row["AdDescription"].ToString(),
                    (decimal)row["Price"],
                    (int)row["CategoryId"],
                    (int)row["CreatedBy"],
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }

            return advertisements;
        }

        public void Update(Advertisement advertisement)
        {
            string sql = "UPDATE Advertisements SET Title = @Title, AdDescription = @Description, Price = @Price, " +
                         "CategoryId = @CategoryId WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Title", advertisement.Title),
            new SqlParameter("@AdDescription", advertisement.AdDescription),
            new SqlParameter("@Price", advertisement.Price),
            new SqlParameter("@CategoryId", advertisement.CategoryId),
            new SqlParameter("@Id", advertisement.Id)
        };

            DataContext.ExecuteNonQuery(sql, parameters);
        }

        public void Delete(int adId)
        {
            string sql = "DELETE FROM Advertisements WHERE Id = @AdId";
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@AdId", adId)
        };

            DataContext.ExecuteNonQuery(sql, parameters);
        }
    }
}
