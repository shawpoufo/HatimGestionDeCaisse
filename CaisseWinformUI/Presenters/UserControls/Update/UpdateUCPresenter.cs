using CaisseWinformUI.Views.UserControls.UpdateScreen;
using Squirrel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters.UserControls.Update
{
    public class UpdateUCPresenter : CaisseWinformUI.Presenters.UserControls.Update.IUpdateUCPresenter
    {
        private IUpdateUC _updateUC;
        public IUpdateUC GetUC { get { return _updateUC; } }

        public UpdateUCPresenter(IUpdateUC updateUC)
        {
            _updateUC = updateUC;
        }

        public async Task UpdateApp()
        {
            try
            {
                using (var mgr = new UpdateManager(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Releases"))))
                {
                    var updateInfo = await mgr.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Any())
                    {
                        var versionCount = updateInfo.ReleasesToApply.Count;
                        var versionWord = versionCount > 1 ? "versions" : "version";
                        if (MessageBox.Show(string.Format("nouvelle version: {0} disponible. voulez vous l'installer? (y/n)", versionCount), "update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {

                            return;

                        }
                        _updateUC.Loading = true;
                        ((UserControl)_updateUC).BringToFront();
                        var updateResult = await mgr.UpdateApp();
                        MessageBox.Show(string.Format(" c'est bien la version {0} est installée , l'application va redémarrer .", updateResult.Version.ToString()));
                        UpdateManager.RestartApp();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
