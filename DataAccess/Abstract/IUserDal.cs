using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); // AuthManager'da (Kayıt-Token işlemleri) kullanıcı giriş/kayıt yaptırırken kullanılacak Token oluşturulurken
                                                   // Veri tabanından Claim'i çekmek için kullanılacaktır.
    }
}
