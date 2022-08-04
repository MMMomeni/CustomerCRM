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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _customerRepositoryAsync, IRegionRepositoryAsync _regionRepositoryAsync)
        {
            customerRepositoryAsync = _customerRepositoryAsync;
            regionRepositoryAsync = _regionRepositoryAsync;
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var customers = await customerRepositoryAsync.GetAllAsync();
            if (customers != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var customer in customers)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = customer.Id;
                    model.Name = customer.Name;
                    model.Title = customer.Title;
                    model.Address = customer.Address;
                    model.City = customer.City;
                    model.RegionId = customer.RegionId;
                    model.PostalCode = customer.PostalCode;
                    model.Country = customer.Country;
                    model.Phone = customer.Phone;
                    model.Photo = customer.Photo;
                    var region = await regionRepositoryAsync.GetByIdAsync(customer.RegionId);
                    model.RegionName = region.Name;

                    result.Add(model);
                }
                return result;
            }
            return null;
            
        }

        public async Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
        {
            Customer c = await customerRepositoryAsync.GetByIdAsync(id);

            if(c != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();

                model.Id = c.Id;
                model.Name = c.Name;
                model.Title = c.Title;
                model.Address = c.Address;
                model.City = c.City;
                model.RegionId = c.RegionId;
                model.PostalCode = c.PostalCode;
                model.Country = c.Country;
                model.Phone = c.Phone;
                model.Photo = c.Photo;
                var regionmodel = await regionRepositoryAsync.GetByIdAsync(c.RegionId);
                model.RegionName = regionmodel.Name;
                
                return model;
            }
            return null;

            
        }

        public Task<int> InsertCustomerAsync(CustomerModel model)
        {
            Customer customer = new Customer()
            {
                Name = model.Name,
                Title = model.Title,
                Address = model.Address,
                City = model.City,
                RegionId = model.RegionId,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Photo = model.Photo
            };

            /* alternative
            Customer customer = new Customer();
            customer.Name = model.Name;
            customer.Title = model.Title;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.RegionId = model.RegionId;
            customer.PostalCode = model.PostalCode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            customer.Photo = model.Photo;
            */
            return customerRepositoryAsync.InsertAsync(customer);
        }

    }
}
