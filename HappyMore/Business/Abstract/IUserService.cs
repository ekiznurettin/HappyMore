using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IList<OperationClaim>> GetClaims(User user);
        IResult Add(UserForRegisterDto userForRegisterDto);
        IResult Update(UserUpdateDto userUpdateDto);
        IResult UpdateImage(User user);
        IResult UpdateLocation(UserLocationDto userLocationDto);
        IDataResult<User> GetByMail(string mail);
        IDataResult<IList<User>> GetAllUsers(int Id);
        IDataResult<IList<User>> GetAll();
        IDataResult<IList<User>> GetAllUsersByUserKey(UserFilterDto userFilterDto);
        IDataResult<User> GetUser(int Id);
        IDataResult<User> GetByUserKey(string userKey);
   
    }
}
