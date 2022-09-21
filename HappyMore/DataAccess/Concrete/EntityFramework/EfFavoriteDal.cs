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
    public class EfFavoriteDal : EfEntityRepositoryBase<Favorite, HappyMoreContext>, IFavoriteDal
    {
        public IDataResult<IList<UserImageDto>> GetUsersWithFavorite(UserKeyDto userKeyDto)
        {
            using (var db = new HappyMoreContext())
            {
                var result = (from user in db.Users
                              join fav in db.Favorites on user.UserKey equals fav.Liking
                              where fav.Liked == userKeyDto.UserKey
                              select new UserImageDto
                              {
                                  Age = user.Age,
                                  ImageUrl = user.ProfileImage,
                                  Name = user.Name,
                                  Surname = user.Surname,
                              });
                return new SuccessDataResult<IList<UserImageDto>>(result.ToList(), "Success");
            }
        }
    }
}
