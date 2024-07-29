namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethaniesPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext bethaniesPieShopDbContext)
        {
            _bethaniesPieShopDbContext = bethaniesPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _bethaniesPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
