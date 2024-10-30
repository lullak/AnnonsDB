namespace AnnonsDatabas.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
    }
}
