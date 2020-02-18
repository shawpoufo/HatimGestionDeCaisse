using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaisseWinformUI.Validators
{
    public class FilterOperationValidator
    {
        public FilterOperationValidator()
        {

        }
        public bool ValidateRegexDate(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^(([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4})$|^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$|^(\d{1,4})$");
            var success1 = regex.Match(datesToValidate[0]).Success;
            var success2 = regex.Match(datesToValidate[1]).Success;
            return (success1 && success2 && (datesToValidate[0].Length == datesToValidate[1].Length));
        }
        public bool ValidateDate(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            if (regex.Match(datesToValidate[0]).Success)
            {
                DateTime fromDateValue1;
                DateTime fromDateValue2;
                var succes1 = DateTime.TryParseExact(datesToValidate[0], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue1);
                var succes2 = DateTime.TryParseExact(datesToValidate[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateValue2);

                return (succes1 && succes2);
            }

            return true;
        }
        public bool DateToShouldBeHigher(List<string> datesToValidate)
        {
            Regex regex = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            if (regex.Match(datesToValidate.First()).Success)
            {
                string[] from = datesToValidate.First().Split('/');
                string[] to = datesToValidate.Last().Split('/');
                DateTime dateFrom = new DateTime(Convert.ToInt32(from[2]), Convert.ToInt32(from[1]), Convert.ToInt32(from[0]));
                DateTime dateTo = new DateTime(Convert.ToInt32(to[2]), Convert.ToInt32(to[1]), Convert.ToInt32(to[0]));

                if (DateTime.Compare(dateTo, dateFrom) >= 0)
                    return true;
            }

            regex = new Regex(@"^((((0)[1-9])|((1)[0-2]))(\/)\d{4})$");

            if (regex.Match(datesToValidate.First()).Success)
            {
                string[] from = datesToValidate.First().Split('/');
                string[] to = datesToValidate.Last().Split('/');
                DateTime dateFrom = new DateTime(Convert.ToInt32(from[1]), Convert.ToInt32(from[0]), 01);
                DateTime dateTo = new DateTime(Convert.ToInt32(to[1]), Convert.ToInt32(to[0]), 12);

                if (DateTime.Compare(dateTo, dateFrom) >= 0)
                    return true;
            }

            regex = new Regex(@"^(\d{1,4})$");
            if (regex.Match(datesToValidate.First()).Success)
            {
                if (Convert.ToInt32(datesToValidate.Last()) >= Convert.ToInt32(datesToValidate.First()))
                    return true;
            }


            return false;
        }
    }
}
