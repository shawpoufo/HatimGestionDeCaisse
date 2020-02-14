using CaisseDTOsLibrary.Models.OperationModel;
using CaisseLogicLibrary.DataAccess.BeneficiaireDataAccess;
using CaisseLogicLibrary.DataAccess.ImputationDataAccess;
using CaisseLogicLibrary.DataAccess.OperationDataAccess;
using CaisseWinformUI.Models;
using CaisseWinformUI.Validators;
using CaisseWinformUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using CaisseDTOsLibrary.Models.ImputationModel;
using CaisseDTOsLibrary.Models.BeneficiaireModel;
using AutoMapper;
using CaisseLogicLibrary.DataAccess.AccountDataAccess;


namespace CaisseWinformUI.Presenters.UserControls
{
    public class AddNewOperationUCPresenter : CaisseWinformUI.Presenters.UserControls.IAddNewOperationUCPresenter
    {
        private IAddNewOperationUC _addNewOperationUC;
        public IAddNewOperationUC GetUC { get { return _addNewOperationUC; } }
        private IOperationData _operationData;
        private IBeneficiaireData _beneficiaireData;
        private IImputationData _imputationData;
        private IOperation _operationDTO;
        private IMapper _mapper;
        private IAccountData _accountData;
        public int IdAccount{get;set;}
        public int IdEditOperation { get; set; }
        private OperationValidator operationValidator;
        public event EventHandler CancelNewOperation;
        public event EventHandler EndOfSaveOperation;
        private decimal _oldIncrement;
        private decimal _oldDecrement;



        public AddNewOperationUCPresenter(IAddNewOperationUC addNewOperationUC, IOperationData operationData, IBeneficiaireData beneficiaireData, IImputationData imputationData, IOperation operationDTO, IMapper mapper,IAccountData accountData)
        {
            _addNewOperationUC = addNewOperationUC;
            _operationData = operationData;
            _beneficiaireData = beneficiaireData;
            _imputationData = imputationData;
            _operationDTO = operationDTO;
            _mapper = mapper;
            _accountData = accountData;
            operationValidator = new OperationValidator();
            SubscribeToEventsSetup();
            _oldIncrement = 0;
            _oldDecrement = 0;
        }

        private void SubscribeToEventsSetup()
        {
            _addNewOperationUC.SaveOperation += _addNewOperationUC_SaveOperation;
            _addNewOperationUC.CancelNewOperation += _addNewOperationUC_CancelNewOperation;
        }

        void _addNewOperationUC_SaveOperation(object sender, EventArgs e)
        {
            OperationModel operationModel = InitilizeOperationModelValues();
            ValidationResult results = operationValidator.Validate(operationModel);
            if (results.IsValid && operationValidator.BeOneOrLessNull(operationModel.incrementer, operationModel.decrementer))
            {
                if (operationModel.imputation == -1)
                {
                    operationModel.imputation = AddNewImputation(new Imputation() { libelle = _addNewOperationUC.GetTextImputation, compte = IdAccount });
                    ProvideImputationDataSource();
                }

                if (operationModel.beneficiaire == -1)
                {
                    operationModel.beneficiaire = AddNewBeneficiaire(new Beneficiaire() { libelle = _addNewOperationUC.GetTextBeneficiaire, compte = IdAccount });
                    ProvideBeneficiareDataSource();
                }
                ChangeDateFormat(operationModel);
                var newOperation = _mapper.Map<OperationModel, Operation>(operationModel);



                if (IdEditOperation > 0)
                {
                    newOperation.id = IdEditOperation;
                    decimal newAccountAmount = NewAccountAmount(Convert.ToDecimal(newOperation.incrementer), _oldIncrement,_accountData.Amount(IdAccount));
                    newAccountAmount = NewAccountAmount(_oldDecrement, Convert.ToDecimal(newOperation.decrementer),newAccountAmount);
                    _operationData.Update(newOperation,newAccountAmount);
                }
                else
                {
                    _operationData.Insert(newOperation, NewAccountAmount(Convert.ToDecimal(newOperation.incrementer), Convert.ToDecimal(newOperation.decrementer), _accountData.Amount(IdAccount)));
                }

                IdEditOperation = 0;

                if (EndOfSaveOperation != null)
                    EndOfSaveOperation(newOperation, EventArgs.Empty);
            }
            else
            {

                if (!operationValidator.BeOneOrLessNull(operationModel.incrementer, operationModel.decrementer))
                    results.Errors.Add(new ValidationFailure("amount", "Veuiller Remplire au moins un de c'est deux champ"));

                if (results.Errors.Count > 0)
                {

                    _addNewOperationUC.SetErrorMessage(results.Errors.ToList());

                }

            }
        }

        void _addNewOperationUC_CancelNewOperation(object sender, EventArgs e)
        {
            if (CancelNewOperation != null)
                CancelNewOperation(this, EventArgs.Empty);
        }


        public void ProvideImputationDataSource()
        {
           
            List<Imputation> imputations = _imputationData.GetAll(IdAccount).Cast<Imputation>().ToList();
            imputations.Insert(0, new Imputation() { id = 0, libelle = "-- Veuillez choisire --" });
            _addNewOperationUC.SetImputationDataSource = imputations;
            
        }
        public void ProvideBeneficiareDataSource()
        {
            List<Beneficiaire> beneficiaires = _beneficiaireData.GetAll(IdAccount).Cast<Beneficiaire>().ToList();
            beneficiaires.Insert(0, new Beneficiaire() { id = 0, libelle = "-- Veuillez choisire --" });
            _addNewOperationUC.SetBeneficiaireDataSource = beneficiaires;
        }

        private OperationModel InitilizeOperationModelValues()
        {
            OperationModel model = new OperationModel();
            model.compte = IdAccount;
            model.date = _addNewOperationUC.Date;

            if (_addNewOperationUC.IdImputation == 0 && _addNewOperationUC.GetTextImputation.ToLower() != ("-- veuillez choisire --").ToLower() && !string.IsNullOrEmpty(_addNewOperationUC.GetTextImputation))
                model.imputation = -1;
            else
                model.imputation = _addNewOperationUC.IdImputation;

            if (_addNewOperationUC.IdBeneficiaire == 0 && _addNewOperationUC.GetTextBeneficiaire.ToLower() != ("-- veuillez choisire --").ToLower() && !string.IsNullOrEmpty(_addNewOperationUC.GetTextBeneficiaire))
                model.beneficiaire = -1;
            else
                model.beneficiaire = _addNewOperationUC.IdBeneficiaire;

            if (string.IsNullOrEmpty(_addNewOperationUC.Increment))
                model.incrementer = null;
            else
                model.incrementer = Convert.ToDouble(_addNewOperationUC.Increment, CultureInfo.InvariantCulture.NumberFormat);

            if (string.IsNullOrEmpty(_addNewOperationUC.Decrement))
                model.decrementer = null;
            else
                model.decrementer = Convert.ToDouble(_addNewOperationUC.Decrement, CultureInfo.InvariantCulture.NumberFormat);


            model.libelle = _addNewOperationUC.Libelle;

            return model;
        }

        private int AddNewImputation(Imputation imputation)
        {
            _imputationData.Insert(imputation);
            return _imputationData.Search(imputation.libelle, imputation.compte);
        }
        private int AddNewBeneficiaire(Beneficiaire beneficiaire)
        {
            _beneficiaireData.Insert(beneficiaire);
            return _beneficiaireData.Search(beneficiaire.libelle, beneficiaire.compte);
        }
        private void ChangeDateFormat(OperationModel operation)
        {
            operation.date = Convert.ToDateTime(operation.date).ToString("yyyy/MM/dd").Replace('/', '-');
            
        }
        public void SetupOperationForEdit(int id)
        {
            ProvideBeneficiareDataSource();
            ProvideImputationDataSource();
            Operation operation = (Operation)_operationData.Get(id);
            _addNewOperationUC.Date = Convert.ToDateTime(operation.date).ToString("dd/MM/yyyy");

            if (operation.imputation == null)
                _addNewOperationUC.IdImputation = 0;
            else
                _addNewOperationUC.IdImputation = Convert.ToInt32(operation.imputation);

            if (operation.beneficiaire == null)
                _addNewOperationUC.IdBeneficiaire = 0;
            else
                _addNewOperationUC.IdBeneficiaire = Convert.ToInt32(operation.beneficiaire);

            _addNewOperationUC.Increment = operation.incrementer.ToString().Replace(',','.');
            _addNewOperationUC.Decrement = operation.decrementer.ToString().Replace(',', '.');
            _addNewOperationUC.Libelle = operation.libelle;
            _addNewOperationUC.Title = "Modifier";

            _oldIncrement = (string.IsNullOrEmpty(_addNewOperationUC.Increment)) ? 0 : Convert.ToDecimal(_addNewOperationUC.Increment, CultureInfo.InvariantCulture.NumberFormat);
            _oldDecrement = (string.IsNullOrEmpty(_addNewOperationUC.Decrement)) ? 0 : Convert.ToDecimal(_addNewOperationUC.Decrement, CultureInfo.InvariantCulture.NumberFormat);

            
        }
        public void ResetOperationForm()
        {
            _addNewOperationUC.SetErrorMessage(new List<ValidationFailure>() { new ValidationFailure("null","null")});
            IdEditOperation = 0;
            _addNewOperationUC.Date = DateTime.Now.ToString("dd/MM/yyyy");
            ProvideBeneficiareDataSource();
            ProvideImputationDataSource();
            _addNewOperationUC.IdImputation = 0;
            _addNewOperationUC.IdBeneficiaire = 0;
            _addNewOperationUC.Increment = "";
            _addNewOperationUC.Decrement = "";
            _addNewOperationUC.Libelle = "";
        }
        private decimal NewAccountAmount(decimal value1, decimal value2,decimal amount)
        {

            return decimal.Add(decimal.Subtract(value1, value2), amount);
        }


        
    }
}
