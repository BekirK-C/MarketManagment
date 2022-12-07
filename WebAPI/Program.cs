using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Autofac.Core;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddDependencyResolvers(new ICoreModule[]  //Cache iþlemi için gerçekleþtirilen dependency resolver.
            //{
            //    new CoreModule()
            //});

            builder.Services.AddSwaggerGen();

            #region .Net Core IoC yapýsý
            //builder.Services.AddSingleton<ICustomerService, CustomerManager>(); // Bu iþlem IoC için yapýlýr.
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>(); 
            #endregion

            #region Autofac Implementasyonu
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(options =>
            {
                options.RegisterModule(new AutofacBusinessModule());
            }); 
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}