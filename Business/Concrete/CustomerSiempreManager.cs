using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerSiempreManager : BaseCustomerManager, ISiempreService
    {
        ICustomerCheckService _customerCheckService;
        public CustomerSiempreManager(ICustomerDal customerDal, ICustomerCheckService customerCheckService) : base(customerDal)
        {
            _customerCheckService = customerCheckService;
        }
        public override IResult Add(Customer customer)
        {
            var result = _customerCheckService.CheckIfRealPerson(customer);
            if (result)
            {
                base.Add(customer);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Not a Valid Person!"); 
            }
        }
    }
}

