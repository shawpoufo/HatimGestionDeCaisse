using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;
using AutoMapper;
using CaisseWinformUI.Views;
using CaisseWinformUI.Views.UserControls;
using CaisseWinformUI.Models;
using CaisseWinformUI.Presenters;
using CaisseWinformUI.Presenters.UserControls;

namespace CaisseWinformUI.Configurations
{
    public static class ContainerConfiguration
    {
        public static IContainer configure()
        {

            //autofac
            var builder = new ContainerBuilder();


            builder.RegisterInstance(new AutoMapperConfiguration().Configure()).As<IMapper>();
            
            builder.RegisterAssemblyTypes(Assembly.Load("CaisseSqlLogicLibrary"))
                .Where(t => t.Namespace.Contains("SqliteDataAccess"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load("CaisseDTOsLibrary"))
                .Where(t => t.Namespace.Contains("Models"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load("CaisseLogicLibrary"))
                .Where(t => t.Namespace != null && t.Namespace.Contains("DataAccess"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            //Views
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<LoginUC>().As<ILoginUC>();
            //Models
            builder.RegisterType<LoginAccountModel>().As<ILoginAccountModel>();
            //Presenters
            builder.RegisterType<LoginViewPresenter>().As<ILoginViewPresenter>();
            builder.RegisterType<LoginUCPresenter>().As<ILoginUCPresenter>();




            return builder.Build();
        }
    }
}
