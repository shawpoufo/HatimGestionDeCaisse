using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaisseDTOsLibrary.Models.FullOperationModel;
using CaisseWinformUI.Models;
namespace CaisseWinformUI.Profiles
{
    class FullOperationProfile:Profile
    {
        public FullOperationProfile()
        {
            CreateMap<FullOperation, FullOperationModel>();
        }
    }
}
