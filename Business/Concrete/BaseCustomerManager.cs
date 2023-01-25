using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public BaseCustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //[SecuredOperation("admin")]
        public virtual IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);
            _customerDal.Add(customer);
            return new SuccessResult("Başarıyla Eklendi");
        }

        //[SecuredOperation("admin,user")]
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
