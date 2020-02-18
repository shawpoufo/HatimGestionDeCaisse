using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseLogicLibrary.DataAccess.OperationDataAccess;
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
using AutoMapper;
using CaisseWinformUI.Models;
using CaisseDTOsLibrary.Models.OperationModel;
using System.Globalization;
using CaisseLogicLibrary.DataAccess.AccountDataAccess;


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
        private IOperationData _operationDataAccess;
        private IMapper _mapper;
        private IAccountData _accountData;

        public int IdCompte { get; set; }
        public event EventHandler EndOfSaveOperation;
        public event EventHandler ActivateFilter;

        public GridOperationsUCPresenter(IGridOperationsUC gridOperationsUC, IAddNewOperationUCPresenter AddNewOperationUCPresenter, IFilterOperationsUCPresenter filterOperationsUCPresenter, IOperationData operationDataAccess, IMapper mapper, IAccountData accountData)
        {
            _gridOperationsUC = gridOperationsUC;
            _AddNewOperationUCPresenter = AddNewOperationUCPresenter;
            _filterOperationsUCPresenter = filterOperationsUCPresenter;
            _operationDataAccess = operationDataAccess;
            _accountData = accountData;
            _mapper = mapper;

            SetUserControlsToPanel();
            SubscribeToEventsSetup();

            
        }
        private void SubscribeToEventsSetup()
        {
            
            _gridOperationsUC.ShowEditOperation += _gridOperationsUC_ShowEditOperation;
            _gridOperationsUC.ShowMessageDeleteOpeartion += _gridOperationsUC_ShowMessageDeleteOpeartion;
            _AddNewOperationUCPresenter.GetUC.CancelNewOperation += GetUC_CancelNewOperation;
            _AddNewOperationUCPresenter.EndOfSaveOperation += _AddNewOperationUCPresenter_EndOfSaveOperation;
            _filterOperationsUCPresenter.EndOfFiltering += _filterOperationsUCPresenter_EndOfFiltering;
            _filterOperationsUCPresenter.CloseFilterForm += _filterOperationsUCPresenter_CloseFilterForm;
            
            
        }

        void _filterOperationsUCPresenter_CloseFilterForm(object sender, EventArgs e)
        {

            _gridOperationsUC.GetAsidePanel.Visible = false;
        }

        void _gridOperationsUC_ShowMessageDeleteOpeartion(object sender, EventArgs e)
        {
            if(MessageBox.Show("Veut tu supprimer cette operation ?","Suppression",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Operation operation = (Operation)_operationDataAccess.Get(Convert.ToInt32(sender));

                _operationDataAccess.Delete(operation, NewAccountAmount(Convert.ToDecimal(operation.decrementer), Convert.ToDecimal(operation.incrementer)));
                if (EndOfSaveOperation != null)
                    EndOfSaveOperation(this, EventArgs.Empty);

            }
        }

        void _filterOperationsUCPresenter_EndOfFiltering(object sender, EventArgs e)
        {
            int filterMonthFrom = (_filterOperationsUCPresenter.GetRistrectedMonths().Count > 0) ? _filterOperationsUCPresenter.GetRistrectedMonths()[0] : 1;
            int filterYearFrom = _filterOperationsUCPresenter.GetRistrectedYears()[0];
            ProvideDgvDataSource(((IEnumerable<IFullOperation>)sender).Cast<FullOperation>().Where(o => o.date.Year == filterYearFrom && o.date.Month == filterMonthFrom).ToList());
            _gridOperationsUC.GetAsidePanel.Visible = false;
            if (ActivateFilter != null)
                ActivateFilter(((IEnumerable<IFullOperation>)sender).Cast<FullOperation>().ToList(), EventArgs.Empty);
            
        }

        void _AddNewOperationUCPresenter_EndOfSaveOperation(object sender, EventArgs e)
        {        
            if (EndOfSaveOperation != null)
                EndOfSaveOperation(this, EventArgs.Empty);

            _AddNewOperationUCPresenter.ResetOperationForm();

            
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

            _AddNewOperationUCPresenter.ResetOperationForm();
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
            _gridOperationsUC.GetDGV.DataSource = AddRowNumber(records);
            _gridOperationsUC.GetDGV.Columns["id"].Visible = false;         
            _gridOperationsUC.GetDGV.Columns.Add(EditColumn());
            _gridOperationsUC.GetDGV.Columns.Add(DeleteColumn());
            ChangeColumnHeaderText();
            ResizeColumn();
            _gridOperationsUC.GetDGV.RowsDefaultCellStyle.NullValue = "Vide";
            _gridOperationsUC.TotalGeneral = CalculateTotal(records.Cast<FullOperation>().ToList()).ToString();
            _gridOperationsUC.GetDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            _gridOperationsUC.GetDGV.Focus();
          

        }
        private DataGridViewImageColumn EditColumn()
        {
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);            
            //var logoimage = Path.Combine(outPutDirectory, "Resources\\editIcon.png");
            //string relLogo = new Uri(logoimage).LocalPath;
            //Image imgAdd = Image.FromFile(relLogo);

            Bitmap imageBmp = Properties.Resources.editIcon;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn() { Name = "editOperation", HeaderText = "Modifier", Image = imageBmp };
            return imageColumn;
        }
        private DataGridViewImageColumn DeleteColumn()
        {
            Bitmap imageBmp = Properties.Resources.deleteIcon;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn() { Name = "deleteOperation", HeaderText = "Supprimer", Image = imageBmp };
            return imageColumn;
        }
        private decimal CalculateTotal(List<FullOperation> records)
        {
            decimal total = 0;
            decimal increment = 0;
            decimal decrement = 0;

            if (records != null && records.Count > 0) 
            {
                foreach (var operation in records)
                {
                    increment += Convert.ToDecimal(operation.incrementer);
                    decrement += Convert.ToDecimal(operation.decrementer);
                }

            }
            _gridOperationsUC.Increment = "+ "+increment.ToString();
            _gridOperationsUC.Decrement = "- "+decrement.ToString();
            total = increment - decrement;
            return total;
        }
        private List<FullOperationModel> AddRowNumber(IEnumerable<IFullOperation> records)
        {
            var newRecords = _mapper.Map<List<FullOperationModel>>(records.Cast<FullOperation>().ToList());

            for (int i = 0; i < newRecords.Count; i++)
            {
                newRecords[i].rowNumber = i+1;
            }
            return newRecords;
        }
        private void ChangeColumnHeaderText()
        {

            _gridOperationsUC.GetDGV.Columns["rowNumber"].HeaderText = "N";
            _gridOperationsUC.GetDGV.Columns["date"].HeaderText = "Date";
            _gridOperationsUC.GetDGV.Columns["imputation"].HeaderText = "Imputation";
            _gridOperationsUC.GetDGV.Columns["incrementer"].HeaderText = "Crédit";
            _gridOperationsUC.GetDGV.Columns["decrementer"].HeaderText = "Débit";
            _gridOperationsUC.GetDGV.Columns["beneficiaire"].HeaderText = "Bénéficiaire";
            _gridOperationsUC.GetDGV.Columns["libelle"].HeaderText = "Libelle";           
        }
        private void ResizeColumn()
        {
            
            foreach (DataGridViewColumn column in _gridOperationsUC.GetDGV.Columns)
            {
                if (column.Name != "libelle" && column.Name != "imputation" && column.Name != "rowNumber")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            _gridOperationsUC.GetDGV.Columns["libelle"].Width = 30;
            _gridOperationsUC.GetDGV.Columns["libelle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _gridOperationsUC.GetDGV.ColumnHeadersHeight = 40;
            _gridOperationsUC.GetDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _gridOperationsUC.GetDGV.Columns["editOperation"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _gridOperationsUC.GetDGV.Columns["deleteOperation"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private decimal NewAccountAmount(decimal value1,decimal value2)
        {
            return decimal.Add(decimal.Subtract(value1, value2), _accountData.Amount(IdCompte));
        }


       
    }
}
