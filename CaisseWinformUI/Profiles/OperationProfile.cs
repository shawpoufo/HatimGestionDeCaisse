using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaisseWinformUI.Models;
using CaisseDTOsLibrary.Models.OperationModel;
namespace CaisseWinformUI.Profiles
{
    class OperationProfile:Profile
    {
        public OperationProfile()
        {
            CreateMap<OperationModel, Operation>();
        }
    }
}
