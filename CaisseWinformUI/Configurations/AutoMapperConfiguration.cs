using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CaisseWinformUI.Configurations
{
    public class AutoMapperConfiguration
    {
        public IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // assembly a changer CaisseWinformUI => CaisseUI
                cfg.AddMaps(Assembly.Load("CaisseUI"));

            });

            return config.CreateMapper();
        }
    }
}
