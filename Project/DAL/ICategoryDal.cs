using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface ICategoryDal
    {
        public Task<Category> Add(Category category);
        public Task<List<Category>> GetAllCategories();
        public Task<bool> DeleteCategory(int CategoryId);
        public Task<Category> UpdateCategory(CategoryDto newCategory, int categoryId);
        public Task<Category> FindCategoryByName(string name);
    }
}
