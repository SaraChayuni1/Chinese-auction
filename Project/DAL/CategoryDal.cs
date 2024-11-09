using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class CategoryDal : ICategoryDal
    {
        private readonly OrdersContext ordersContext;

        public CategoryDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Category> Add(Category category)
        {
            try
            {
                await ordersContext.Category.AddAsync(category);
                await ordersContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                List<Category> categorys = await ordersContext.Category.ToListAsync();
                return categorys;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteCategory(int CategoryId)
        {
            try
            {
                List<Category> categorys = await ordersContext.Category.ToListAsync();
                Category deleteCategory = categorys.FirstOrDefault(p => p.Id == CategoryId);
                if (deleteCategory == null)
                {
                    return false;
                }
                else
                {
                    ordersContext.Category.Remove(deleteCategory);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Category> UpdateCategory(CategoryDto newCategory, int categoryId)
        {
            try
            {
                Category categoryToUpdate = await ordersContext.Category.FirstOrDefaultAsync(p => p.Id == categoryId);
                if (categoryToUpdate == null)
                {
                    return null;
                }
                else
                {
                    ordersContext.Category.Update(categoryToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return categoryToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UpdatePresent failed");
            }
        }
        public async Task<Category> FindCategoryByName(string name)
        {
            try
            {
                List<Category> categorys = await ordersContext.Category.ToListAsync();
                Category category = categorys.FirstOrDefault(p => p.Name == name);
                if (category == null)
                {
                    return null;
                }
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }


    }
}
