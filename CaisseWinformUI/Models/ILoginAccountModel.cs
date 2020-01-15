using System;
namespace CaisseWinformUI.Models
{
    public interface ILoginAccountModel
    {
        int id { get; set; }
        string password { get; set; }
        string username { get; set; }
    }
}
