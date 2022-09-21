using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFavoriteService
    {
        IResult Add(Favorite favorite);
        IResult Update(Favorite favorite);
        IResult Delete(string Liking,string liked);
        IDataResult<Favorite> Get(string Liking,string liked);
        IDataResult<IList<UserImageDto>> GetAllByUserKey(UserKeyDto userKeyDto);
    }
}
