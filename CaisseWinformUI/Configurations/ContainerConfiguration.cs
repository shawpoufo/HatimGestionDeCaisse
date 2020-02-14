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
using CaisseWinformUI.Views.UserControls.Manage;
using CaisseWinformUI.Presenters.UserControls.Manage;
using CaisseWinformUI.Views.UserControls.DownLoad;
using CaisseWinformUI.Presenters.UserControls.DownLoad;
using CaisseWinformUI.Reporting;

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
                .Where(t => t.Namespace.EndsWith("DataAccess"))
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
            builder.RegisterType<SignUpUC>().As<ISignUpUC>();
            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<HeaderUC>().As<IHeaderUC>();
            builder.RegisterType<OperationsUC>().As<IOperationsUC>();
            builder.RegisterType<SearchOperationsUC>().As<ISearchOperationsUC>();
            builder.RegisterType<GridOperationsUC>().As<IGridOperationsUC>();
            builder.RegisterType<AddNewOperationUC>().As<IAddNewOperationUC>();
            builder.RegisterType<FilterOperationsUC>().As<IFilterOperationsUC>();
            builder.RegisterType<MoveOperationsUC>().As<IMoveOperationsUC>();
            builder.RegisterType<ManageUC>().As<IManageUC>();
            builder.RegisterType<DownLoadUC>().As<IDownLoadUC>();
            
            //Models
            builder.RegisterType<LoginAccountModel>().As<ILoginAccountModel>();
            builder.RegisterType<OperationModel>().As<IOperationModel>();
            builder.RegisterType<FullOperationModel>().As<IFullOperationModel>();
            //Presenters
            builder.RegisterType<LoginViewPresenter>().As<ILoginViewPresenter>();
            builder.RegisterType<LoginUCPresenter>().As<ILoginUCPresenter>();
            builder.RegisterType<SignUpUCPresenter>().As<ISignUpUCPresenter>();
            builder.RegisterType<MainViewPresenter>().As<IMainViewPresenter>();
            builder.RegisterType<HeaderUCPresenter>().As<IHeaderUCPresenter>();
            builder.RegisterType<OperationsUCPresenter>().As<IOperationsUCPresenter>();
            builder.RegisterType<SearchOperationsUCPresenter>().As<ISearchOperationsUCPresenter>();
            builder.RegisterType<GridOperationsUCPresenter>().As<IGridOperationsUCPresenter>();
            builder.RegisterType<AddNewOperationUCPresenter>().As<IAddNewOperationUCPresenter>();
            builder.RegisterType<FilterOperationsUCPresenter>().As<IFilterOperationsUCPresenter>();
            builder.RegisterType<MoveOperationsUCPresenter>().As<IMoveOperationsUCPresenter>();
            builder.RegisterType<ManageUCPresenter>().As<IManageUCPresenter>();
            builder.RegisterType<DownLoadUCPresenter>().As<IDownLoadUCPresenter>();
            //Services
            builder.RegisterType<ExportToExcel>().As<IExportToExcel>();




            return builder.Build();
        }
    }
}
