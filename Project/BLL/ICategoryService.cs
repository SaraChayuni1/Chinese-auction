using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public interface ICategoryService
    {
        public Task<Category> Add(Category category);
        public Task<List<Category>> GetAllCategories();
        public Task<bool> DeleteCategory(int categoryId);
        public Task<Category> UpdateCategory(CategoryDto newCategory,int categoryId);
        public Task<Category> FindCategoryByName(string name);

    }
}
