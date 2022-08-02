using CustomerCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Contracts.Service
{
    public interface ICustomerServiceAsync
    {
        Task<int> InsertCustomerAsync(CustomerModel model);
        Task<CustomerResponseModel> GetCustomerByIdAsync(int id);
        Task<IEnumerable<CustomerResponseModel>> GetAllAsync();

    }
}
