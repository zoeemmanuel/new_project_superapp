using Super_new_project.Models.Northwind;

namespace Super_new_project.Northwind
{
    public interface INorthwindService
    {
        Task<List<CategoriesType>> GetCategories();
    }
}
