using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Models
{
    public class LoginAccountModel : ILoginAccountModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
