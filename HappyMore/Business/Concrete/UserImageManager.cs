using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        private readonly IUserImageDal _userImageDal;

        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }

        public IResult Add(UserImage userImage)
        {
            var result = _userImageDal.Get(a => a.ImageUrl == userImage.ImageUrl);
            if (result == null)
            {
                _userImageDal.Add(userImage);
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }

        public IResult Delete(int Id)
        {
            var result = _userImageDal.Get(a => a.Id == Id);
            if (result != null)
            {
                _userImageDal.Delete(result);
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }

        public IDataResult<IList<UserImage>> GetAllByUserKey(string userKey)
        {
            var result = _userImageDal.GetList(a => a.UserKey == userKey);
            if (result.Count > 0)
            {
                return new SuccessDataResult<IList<UserImage>>(result, "Başarılı");
            }
            return new ErrorDataResult<IList<UserImage>>(null, "Başarısız");
        }

        public IDataResult<UserImage> GetByUserKey(string userKey)
        {
            var result = _userImageDal.Get(a => a.UserKey == userKey);
            if (result != null)
            {
                return new SuccessDataResult<UserImage>(result, "Başarılı");
            }
            return new ErrorDataResult<UserImage>(null, "Başarısız");
        }

        public IResult Update(UserImage userImage)
        {
            var result = _userImageDal.Get(a => a.ImageUrl == userImage.ImageUrl);
            if (result != null)
            {
                _userImageDal.Update(result);
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
