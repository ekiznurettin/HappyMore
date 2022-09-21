using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HappyMoreContext>, IUserDal
    {
        public IList<OperationClaim> GetClaims(User user)
        {
            using (var db = new HappyMoreContext())
            {
                var result = (from operationClaim in db.OperationClaims
                             join userOperationClaim in db.UserOperationClaims
                              on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             });
                return result.ToList();
            }
        }

        public IList<User> GetUsersWithBloked(string userKey)
        {
            using (var db = new HappyMoreContext())
            {
                var result = (from user in db.Users
                              join fav in db.Favorites on user.UserKey equals fav.Liked
                              where user.UserKey != userKey
                              select user);
                return result.ToList();
            }
        }
    }
}
