using System;
using Bogus;
using K123ShopApp.DataAccess.Concrete.EntityFramework;
using K123ShopApp.Entities.Concrete;

namespace K123ShopApp.DataAccess.DataSeeder
{
	public static class BogusDataCreator
	{
		public static void CreateFakeData()
		{
			using var context = new AppDbContext();

			if (!context.Categories.Any())
			{
				var fakeCategories = new Faker<Category>();

				fakeCategories.RuleFor(x => x.CategoryName, y => y.Commerce.Categories(1)[0]);
				fakeCategories.RuleFor(x => x.IsActive, y => y.Random.Bool());
				fakeCategories.RuleFor(x => x.IsDeleted, y => y.Random.Bool());
				fakeCategories.RuleFor(x => x.IsFeatured, y => y.Random.Bool());
				fakeCategories.RuleFor(x => x.IsNavbar, y => y.Random.Bool());
				fakeCategories.RuleFor(x => x.CreatedDate, y => y.Date.Recent());
				fakeCategories.RuleFor(x => x.PhotoUrl, y => y.Image.LoremPixelUrl());

				var result = fakeCategories.Generate(25);
				context.Categories.AddRange(result);
				context.SaveChanges();
            }


            if (!context.Products.Any())
            {
                var fakeProducts = new Faker<Product>();

                fakeProducts.RuleFor(x => x.ProductName, y => y.Commerce.ProductName());
                fakeProducts.RuleFor(x => x.IsActive, y => y.Random.Bool());
                fakeProducts.RuleFor(x => x.IsDeleted, y => y.Random.Bool());
                fakeProducts.RuleFor(x => x.IsFeatured, y => y.Random.Bool());
                fakeProducts.RuleFor(x => x.CreatedDate, y => y.Date.Recent());
                fakeProducts.RuleFor(x => x.PhotoUrl, y => y.Image.LoremPixelUrl());
				fakeProducts.RuleFor(x => x.CategoryId, y => y.Random.Int(1, 25));
                fakeProducts.RuleFor(x => x.Price, y => y.Random.Int(100, 1000));
				fakeProducts.RuleFor(x => x.Description, y => y.Commerce.ProductDescription());
                fakeProducts.RuleFor(x => x.Quantity, y => y.Random.Int(100, 300));

                var result = fakeProducts.Generate(100);
                context.Products.AddRange(result);
                context.SaveChanges();
            }

        }
	}
}

