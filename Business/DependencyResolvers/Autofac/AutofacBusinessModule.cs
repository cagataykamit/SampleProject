﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            builder.RegisterType<StockTypeManager>().As<IStockTypeService>().SingleInstance();
            builder.RegisterType<EfStockTypeDal>().As<IStockTypeDal>().SingleInstance();

            builder.RegisterType<StockUnitManager>().As<IStockUnitService>().SingleInstance();
            builder.RegisterType<EfStockUnitDal>().As<IStockUnitDal>().SingleInstance();

            builder.RegisterType<StockListManager>().As<IStockListService>().SingleInstance();
            builder.RegisterType<EfStockListDal>().As<IStockListDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
