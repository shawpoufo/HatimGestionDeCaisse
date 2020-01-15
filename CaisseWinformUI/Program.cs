using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaisseWinformUI.Configurations;
using Autofac;
using CaisseWinformUI.Views;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using CaisseLogicLibrary.DataAccess.SignUp;
using CaisseLogicLibrary.DataAccess.SearchOperations;
using CaisseWinformUI.Presenters;
namespace CaisseWinformUI
{
     static class Program
     {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          [STAThread]
          static void Main()
          {
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);

               var container = ContainerConfiguration.configure();

              using(container.BeginLifetimeScope())
              {
                  var loginViewPresenter =  container.Resolve<ILoginViewPresenter>();
                  var loginView = loginViewPresenter.GetLoginView();

                  Application.Run(loginView);
              }

               
          }
     }
}
