using CaisseDTOsLibrary.Models.FilterOperationModel;
using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaisseLogicLibrary.DataAccess.FilterOperationDataAccess
{
    public class FilterOperationData : CaisseLogicLibrary.DataAccess.FilterOperationDataAccess.IFilterOperationData
    {   
        private ISqliteDataAccess _sqliteDataAccess;
        private StringBuilder query;
        private DynamicParameters parameters;
        

        public FilterOperationData(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;
            query = new StringBuilder("");
            parameters = new DynamicParameters();
            
        }
        public IEnumerable<IFullOperation> Filter(IFilterOperation filterOperationModel)
        {
            query = new StringBuilder("");
            query.Append(
                    @"select o.id,o.date, " +
                    "i.libelle as imputation, " +
                    "o.incrementer,o.decrementer, " +
                    "b.libelle as beneficiaire, " +
                    "o.libelle " +
                    "from Operation o " +
                    "LEFT JOIN Imputation i ON i.id = o.imputation " +
                    "LEFT JOIN Beneficiaire b ON b.id = o.beneficiaire " +
                    "LEFT JOIN Compte c ON c.id = o.compte " +
                    "where o.compte = @compte ");

            parameters.Add("@compte", filterOperationModel.compte, DbType.Int32);
            FilterByDate(filterOperationModel);
            FilterByImputations(filterOperationModel);
            FilterByBeneficiaire(filterOperationModel);
            FilterByLibelle(filterOperationModel);
            query.Append(@"ORDER by o.date ASC ");

            return _sqliteDataAccess.LoadData<FullOperation, dynamic>(query.ToString(), parameters);
            
        }
        private void FilterByDate(IFilterOperation filterOperationModel)
        {
            int indexRegex = ValidateRegexDate(filterOperationModel.dateFrom);
            if (indexRegex == 0 || indexRegex == 1)
            {
                if (indexRegex == 1)
                {
                    Convert.ToDateTime(filterOperationModel.dateFrom).ToString("01/MM/yyyy");
                    int month = Convert.ToInt32(filterOperationModel.dateTo.Split('/').ToList().First());
                    int year = Convert.ToInt32(filterOperationModel.dateTo.Split('/').ToList().Last());
                    int numberOfDays = DateTime.DaysInMonth(year, month);
                    filterOperationModel.dateTo = (new DateTime(year, month, numberOfDays).ToString("dd/MM/yyyy"));
                }
                query.Append("and o.date between @dateFrom and @dateTo ");
                parameters.Add("@dateFrom", Convert.ToDateTime(filterOperationModel.dateFrom.Replace('/', '-')).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
                parameters.Add("@dateTo", Convert.ToDateTime(filterOperationModel.dateTo.Replace('/', '-')).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            }
            else
            {
                query.Append("and strftime('%Y',o.date) between @dateFrom and @dateTo ");
                parameters.Add("@dateFrom", filterOperationModel.dateFrom, DbType.String, ParameterDirection.Input);
                parameters.Add("@dateTo", filterOperationModel.dateTo, DbType.String, ParameterDirection.Input);
            }


        }
        private void FilterByImputations(IFilterOperation filterOperationModel)
        {
            if (filterOperationModel.listImputation.ToList().Count > 0)
            {
                query.Append("and o.imputation in @listImputation ");
                parameters.Add("@listImputation", filterOperationModel.listImputation); 
            }
        }
        private void FilterByBeneficiaire(IFilterOperation filterOperationModel)
        {
            if (filterOperationModel.listBeneficiare.ToList().Count > 0)
            {
                query.Append("and o.beneficiaire in @listBeneficiare ");
                parameters.Add("@listBeneficiare", filterOperationModel.listBeneficiare);
            }
        }
        private void FilterByLibelle(IFilterOperation filterOperationModel)
        {
            if (filterOperationModel.listLibelle.Count > 0)
            {
                int i = 0;
                query.Append("and ( ");
                foreach(var libelle in filterOperationModel.listLibelle)
                {
                    if (!string.IsNullOrEmpty(libelle))
                    {
                        if (i == 0)
                        {
                            query.Append(" o.libelle LIKE @libelle" + (++i));
                            parameters.Add("@libelle" + i, "%" + libelle.Trim() + "%", DbType.String);
                        }
                        else
                        {
                            query.Append(" OR o.libelle LIKE @libelle" + (++i));
                            parameters.Add("@libelle" + i, "%" + libelle.Trim() + "%", DbType.String);
                        } 
                    }
                }
                query.Append(" ) ");
                
            }
        }

        private int ValidateRegexDate(string dateToValidate)
        {
            List<string> patterns = new List<string>();
            patterns.Add(@"^(([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4})$");
            patterns.Add(@"^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$");
            patterns.Add(@"^(\d{1,4})$");
            Regex regex = new Regex("");
            foreach(var pattern in patterns)
            {
                regex = new Regex(pattern);
                if (regex.Match(dateToValidate).Success)
                    return patterns.IndexOf(pattern);
            }
            return 2;
        }
    }
}
