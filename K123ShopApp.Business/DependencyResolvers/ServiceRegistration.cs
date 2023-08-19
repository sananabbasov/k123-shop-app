using System;
using AutoMapper;
using K123ShopApp.Business.Abstract;
using K123ShopApp.Business.AutoMapper;
using K123ShopApp.Business.Concrete;
using K123ShopApp.Business.Consumers;
using K123ShopApp.Core.EventBus;
using K123ShopApp.Core.EventBus.RabbitMq;
using K123ShopApp.Core.Utilities.MailHelper;
using K123ShopApp.DataAccess.Abstract;
using K123ShopApp.DataAccess.Concrete.EntityFramework;
using K123ShopApp.DataAccess.DataSeeder;
using K123ShopApp.Entities.SharedModels;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace K123ShopApp.Business.DependencyResolvers
{
	public static class ServiceRegistration
	{
		public static void AddBusinessRegistration(this IServiceCollection services)
		{
            services.AddScoped<AppDbContext>();

			services.AddScoped<IProductDal, EfProductDal>();
			services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<ISpecificationDal, EfSpecificationDal>();
            services.AddScoped<ISpecificationService, SpecificationManager>();

            services.AddScoped<IWishListDal, EfWishListDal>();
            services.AddScoped<IWishListService, WishListManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IMailSender, MailSender>();


            services.AddScoped<IServiceBus, RabbitMqServiceBus>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddMassTransit(config =>
            {
                config.AddConsumer<SendEmailConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost");
                    cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));

                    cfg.ReceiveEndpoint("send-email-command", c =>
                    {
                        c.ConfigureConsumer<SendEmailConsumer>(ctx);
                    });
                });
            });



            BogusDataCreator.CreateFakeData();


        }
    }
}

