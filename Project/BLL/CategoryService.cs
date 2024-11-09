using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        public async Task<Category> Add(Category category)
        {

            return await categoryDal.Add(category);
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await categoryDal.GetAllCategories();
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            return await categoryDal.DeleteCategory(CategoryId);
        }

        public async Task<Category> UpdateCategory(CategoryDto newCategory, int categoryId)
        {
            return await categoryDal.UpdateCategory(newCategory, categoryId);
        }

        public async Task<Category> FindCategoryByName(string name)
        {
            return await categoryDal.FindCategoryByName(name);
        }
    }
}

