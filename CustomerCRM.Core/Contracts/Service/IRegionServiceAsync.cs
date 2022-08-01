using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface IRegionServiceAsync
    {
        Task<int> InsertRegion(RegionModel regionModel);
        Task<IEnumerable<RegionModel>> GetAllRegions();
        Task<int> DeleteRegion(int regionId);
        Task<int> UpdateRegion(RegionModel regionModel);
        Task<RegionModel> GetRegionById(int regionId);
    }
}
