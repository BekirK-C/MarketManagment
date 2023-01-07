﻿using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class CustomerHermasoManager : BaseCustomerManager, IHermasoService
    {
        public CustomerHermasoManager(ICustomerDal customerDal) : base(customerDal)
        {
        }
    }
}
