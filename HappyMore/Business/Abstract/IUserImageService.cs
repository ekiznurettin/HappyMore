using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(UserImage userImage);
        IResult Update(UserImage userImage);
        IResult Delete(int Id);
        IDataResult<IList<UserImage>> GetAllByUserKey(string userKey);
        IDataResult<UserImage> GetByUserKey(string userKey);
    }
}
