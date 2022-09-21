using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        IList<OperationClaim> GetClaims(User user);
       
        IList<User> GetUsersWithBloked(string userKey);
    }
}
