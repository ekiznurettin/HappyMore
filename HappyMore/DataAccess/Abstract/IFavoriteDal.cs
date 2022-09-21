using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IFavoriteDal : IEntityRepository<Favorite>
    {
        IDataResult<IList<UserImageDto>> GetUsersWithFavorite(UserKeyDto userKeyDto);
    }
}
