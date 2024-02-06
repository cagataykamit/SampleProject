using Autofac;
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
           

            builder.RegisterType<StockTypeManager>().As<IStockTypeService>().SingleInstance();
            builder.RegisterType<EfStockTypeDal>().As<IStockTypeDal>().SingleInstance();

            builder.RegisterType<StockUnitManager>().As<IStockUnitService>().SingleInstance();
            builder.RegisterType<EfStockUnitDal>().As<IStockUnitDal>().SingleInstance();

            builder.RegisterType<StockListManager>().As<IStockListService>().SingleInstance();
            builder.RegisterType<EfStockListDal>().As<IStockListDal>().SingleInstance();

            builder.RegisterType<QuantityUnitManager>().As<IQuantityUnitService>().SingleInstance();
            builder.RegisterType<EfQuantityUnitDal>().As<IQuantityUnitDal>().SingleInstance();

            builder.RegisterType<CurrencyTypeManager>().As<ICurrencyTypeService>().SingleInstance();
            builder.RegisterType<EfCurrencyTypeDal>().As<ICurrencyTypeDal>().SingleInstance();

            builder.RegisterType<StockClassManager>().As<IStockClassService>().SingleInstance();
            builder.RegisterType<EfStockClassDal>().As<IStockClassDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
