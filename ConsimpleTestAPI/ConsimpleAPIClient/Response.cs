namespace ConsimpleTestAPI.ConsimpleAPIClient
{
    public class Response
    {
        public Product[] Products { get; set; }
        public Category[] Categories { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}