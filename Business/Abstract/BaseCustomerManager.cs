using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public BaseCustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public virtual IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "Başarıyla Listelendi");
        }

        public IDataResult<Customer> GetByCustomertId(int customerId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
