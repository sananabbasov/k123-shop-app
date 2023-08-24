using System;
using K123ShopApp.Core.DataAccess.EntityFramework;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>, ICategoryDal
    {
        public async Task AddCategoryAsync(Category category)
        {
            using var context = new AppDbContext();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }
    }
}

