using IAssetTechnical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAssetTechnical.Repositories
{
    public interface IDynamicRepository
    {
        IWeatherRepository GetRepository(bool useMock);
    }    
}
