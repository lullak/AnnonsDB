namespace AnnonsDatabas.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AdDescription { get; set; }
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Advertisement(int id, string title, string adDescription, decimal price, int categoryId, int createdBy, DateTime createdDate)
        {
            Id = id;
            Title = title;
            AdDescription = adDescription;
            Price = price;
            CategoryId = categoryId;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }

        public override string ToString()
        {
            return $"{Title} - {Price:C} - {CreatedDate:yyyy-MM-dd}\n {AdDescription}";
        }
    }
}
