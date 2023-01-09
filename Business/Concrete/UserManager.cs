using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı Silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar Listelendi");
        }

        public IDataResult<User> GetByMail(string email)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), "Kullanıcı Listelendi");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetUser(int userId)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), "Kullanıcı Listelendi");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
