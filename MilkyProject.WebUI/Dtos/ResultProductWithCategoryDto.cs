namespace MilkyProject.WebUI.Dtos
{
    public class ResultProductWithCategoryDto
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal oldPrice { get; set; }
        public decimal newPrice { get; set; }
        public string imageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public class Category
        {
            public string CategoryName { get; set; }

        }

    }
}
