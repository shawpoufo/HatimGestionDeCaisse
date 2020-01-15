using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using CaisseWinformUI.Models;

namespace CaisseWinformUI.Profiles
{
    public class LoginAccountProfile : Profile
    {
        public LoginAccountProfile()
        {
            CreateMap<LoginAccountModel,LoginAccount>();
        }
    }
}
