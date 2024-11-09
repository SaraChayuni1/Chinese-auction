using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        [HttpPost("/Category/Add")]
        public async Task<Category> Add(CategoryDto category)
        {
            var c = mapper.Map<Category>(category);
            return await categoryService.Add(c);

        }
        [HttpGet("/Category/GetAllCategories")]
        public async Task<List<Category>> GetAllCategories()
        {
            return await categoryService.GetAllCategories();
        }
        [HttpDelete("/Category/{CategoryId}")]
        public async Task<bool>DeleteCategory(int CategoryId)
        {
            return await categoryService.DeleteCategory(CategoryId);
        }
        [HttpPut("/Category/{categoryId}")]
        public async Task<Category> UpdateCategory(CategoryDto newCategory, int categoryId)
        {
            return await categoryService.UpdateCategory(newCategory, categoryId);
        }
        [HttpGet("/Category/{categoryByName}")]
        public async Task<Category> FindCategoryByName(string categoryByName)
        {
            return await categoryService.FindCategoryByName(categoryByName);
        }
    }

}
