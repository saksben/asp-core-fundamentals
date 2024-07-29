namespace BethanysPieShop.Models
{
    // Interface for Category Repo
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
