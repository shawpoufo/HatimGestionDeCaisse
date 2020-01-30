using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaisseWinformUI.Presenters.UserControls
{
    public class GridOperationsUCPresenter : CaisseWinformUI.Presenters.UserControls.IGridOperationsUCPresenter
    {
        private IGridOperationsUC _gridOperationsUC;
        private IAddNewOperationUCPresenter _AddNewOperationUCPresenter;         
        public IAddNewOperationUCPresenter GetNewOperationPresenter { get { return _AddNewOperationUCPresenter; } }
        private IFilterOperationsUCPresenter _filterOperationsUCPresenter;
        public IFilterOperationsUCPresenter GetFilterOperationsUCPresenter { get { return _filterOperationsUCPresenter; } }
        public IGridOperationsUC GetUC { get { return _gridOperationsUC; } }
        public int IdCompte { get; set; }
        public event EventHandler EndOfSaveOperation;
        public event EventHandler ActivateFilter;

        public GridOperationsUCPresenter(IGridOperationsUC gridOperationsUC, IAddNewOperationUCPresenter AddNewOperationUCPresenter, IFilterOperationsUCPresenter filterOperationsUCPresenter)
        {
            _gridOperationsUC = gridOperationsUC;
            _AddNewOperationUCPresenter = AddNewOperationUCPresenter;
            _filterOperationsUCPresenter = filterOperationsUCPresenter;
            SetUserControlsToPanel();
            SubscribeToEventsSetup();
            
        }
        private void SubscribeToEventsSetup()
        {
            _AddNewOperationUCPresenter.GetUC.CancelNewOperation += GetUC_CancelNewOperation;
            _gridOperationsUC.ShowEditOperation += _gridOperationsUC_ShowEditOperation;
            _AddNewOperationUCPresenter.EndOfSaveOperation += _AddNewOperationUCPresenter_EndOfSaveOperation;
            _filterOperationsUCPresenter.EndOfFiltering += _filterOperationsUCPresenter_EndOfFiltering;
        }

        void _filterOperationsUCPresenter_EndOfFiltering(object sender, EventArgs e)
        {
            int filterMonthFrom = (_filterOperationsUCPresenter.GetRistrectedMonths().Count > 0) ? _filterOperationsUCPresenter.GetRistrectedMonths()[0] : 1;
            int filterYearFrom = _filterOperationsUCPresenter.GetRistrectedYears()[0];
            ProvideDgvDataSource(((IEnumerable<IFullOperation>)sender).Cast<FullOperation>().Where(o => o.date.Year == filterYearFrom && o.date.Month == filterMonthFrom).ToList());
            if (ActivateFilter != null)
                ActivateFilter(((IEnumerable<IFullOperation>)sender).Cast<FullOperation>().ToList(), EventArgs.Empty);
            
        }

        void _AddNewOperationUCPresenter_EndOfSaveOperation(object sender, EventArgs e)
        {
            if (EndOfSaveOperation != null)
                EndOfSaveOperation(this, EventArgs.Empty);
        }

        void _gridOperationsUC_ShowEditOperation(object sender, EventArgs e)
        {
            _gridOperationsUC.GetAsidePanel.Visible = true;
            ((UserControl)_AddNewOperationUCPresenter.GetUC).BringToFront();
            _AddNewOperationUCPresenter.IdEditOperation = Convert.ToInt32(sender);
            _AddNewOperationUCPresenter.SetupOperationForEdit(Convert.ToInt32(sender));
        }

        void GetUC_CancelNewOperation(object sender, EventArgs e)
        {
            _gridOperationsUC.GetAsidePanel.Visible = false;
            
        }
        private void SetUserControlsToPanel()
        {
            _AddNewOperationUCPresenter.GetUC.SetParent(_gridOperationsUC.GetAsidePanel);
            _filterOperationsUCPresenter.GetUC.SetParent(_gridOperationsUC.GetAsidePanel);
            
        }
        public void ProvideDgvDataSource(IEnumerable<IFullOperation> records)
        {
            if (_gridOperationsUC.GetDGV.Columns.Count > 0) _gridOperationsUC.GetDGV.Columns.Clear();
            _gridOperationsUC.GetDGV.DataSource = null;
            _gridOperationsUC.GetDGV.DataSource = records;
            _gridOperationsUC.GetDGV.Columns["id"].Visible = false;
            _gridOperationsUC.GetDGV.Columns["libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _gridOperationsUC.GetDGV.Columns.Add(EditColumn());


        }
        private DataGridViewImageColumn EditColumn()
        {
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);            
            //var logoimage = Path.Combine(outPutDirectory, "Resources\\editIcon.png");
            //string relLogo = new Uri(logoimage).LocalPath;
            //Image imgAdd = Image.FromFile(relLogo);

            Bitmap imageBmp = Properties.Resources.editIcon;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn() { Name = "editOperation", HeaderText = "Edit", Image = imageBmp };
            return imageColumn;
        }
        
    }
}
