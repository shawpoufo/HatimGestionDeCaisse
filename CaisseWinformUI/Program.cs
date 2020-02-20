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
using CaisseLogicLibrary.DataAccess.GenerateDatabase;
using Squirrel;
using System.IO;
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

            using (container.BeginLifetimeScope())
            {
                var createDB = container.Resolve<ICreateDatabase>();
                using (var mgr = new UpdateManager(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Releases"))))
                {
                    // Note, in most of these scenarios, the app exits after this method
                    // completes!
                    SquirrelAwareApp.HandleEvents(
                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                      
                      onAppUpdate: v =>
                      {
                          mgr.CreateShortcutForThisExe();
                          createDB.Create();
                      },
                      onAppUninstall: v =>
                      {
                          Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CaisseUIData"), true);
                          mgr.RemoveShortcutForThisExe();
                      },
                      onFirstRun: () => createDB.Create()

                      );
                }

                var loginViewPresenter = container.Resolve<ILoginViewPresenter>();
                var loginView = loginViewPresenter.GetLoginView();

                Application.Run(loginView);
            }


        }
    }
}
