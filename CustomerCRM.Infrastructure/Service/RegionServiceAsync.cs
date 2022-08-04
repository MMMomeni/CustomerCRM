using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Entities;
using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Service
{
    public class RegionServiceAsync : IRegionServiceAsync
    {
        private readonly IRegionRepositoryAsync regionRepository;
        public RegionServiceAsync(IRegionRepositoryAsync _regionRepository)
        {
            regionRepository = _regionRepository;
        }

        public Task<int> InsertRegion(RegionModel regionModel)
        {
            Region regionEntity = new Region();
            regionEntity.Name = regionModel.Name;
            return  regionRepository.InsertAsync(regionEntity);
        }
         
        public async Task<IEnumerable<RegionModel>> GetAllRegions()
        {
            var result = await regionRepository.GetAllAsync();
            List<RegionModel> regions = new List<RegionModel>();
            foreach (var item in result)
            {
                RegionModel r = new RegionModel();
                r.Id = item.Id;
                r.Name = item.Name;
                regions.Add(r);
            }
            return regions;
        }

        public  Task<int> DeleteRegion(int regionId)
        {
            return  regionRepository.DeleteAsync(regionId);
        }


        public Task<int> UpdateRegion(RegionModel regionModel)
        {
            // regionRepository.DeleteAsync(regionModel.Id);
            Region regionEntity = new Region();
            regionEntity.Id = regionModel.Id;
            regionEntity.Name = regionModel.Name;
            return  regionRepository.UpdateAsync(regionEntity);

        }

        public async Task<RegionModel> GetRegionById(int id)
        {
            Region entity = await regionRepository.GetByIdAsync(id);
            if (entity != null)
            {
                RegionModel regionModel = new RegionModel() 
                { 
                    Id = entity.Id, 
                    Name = entity.Name
                };
                return regionModel;
            }
            return null;
            
        }
    }
}
