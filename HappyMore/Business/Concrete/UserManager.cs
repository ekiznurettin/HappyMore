using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public IResult Add(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = _mapper.Map<User>(userForRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IsBio = 1;
            user.IsGender = 2;
            user.IsPlace = 2;
            user.ProfileImage = "images/userImages/default.png";
            user.Status = 2;
            _userDal.Add(user);
            return new SuccessResult("Success");
        }
        public IDataResult<IList<User>> GetAllUsers(int Id)
        {
            return new SuccessDataResult<IList<User>>(_userDal.GetList(x => x.UserId != Id));
        }
        public IDataResult<IList<User>> GetAll()
        {
            return new SuccessDataResult<IList<User>>(_userDal.GetList());
        }
        public IDataResult<IList<User>> GetAllUsersByUserKey(UserFilterDto userFilterDto)
        {
            return new SuccessDataResult<IList<User>>(_userDal.GetList(x => x.UserKey != userFilterDto.UserKey));
        }
        public IDataResult<User> GetByMail(string mail)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Mail == mail));
        }
        public IDataResult<User> GetByUserKey(string userKey)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserKey == userKey));
        }
        public IDataResult<IList<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<IList<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetUser(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserId == Id));
        }

        public IResult Update(UserUpdateDto userUpdateDto)
        {
            var user = _userDal.Get(x => x.UserKey == userUpdateDto.UserKey);
            if (user != null)
            {
                user.Name = userUpdateDto.Name;
                user.Surname = userUpdateDto.Surname;
                user.Address = userUpdateDto.Address;
                user.Bio = userUpdateDto.Bio;
                user.Phone = userUpdateDto.Phone;
                user.Instagram = userUpdateDto.Instagram;
                user.Hobiler = userUpdateDto.Hobiler;
                user.Gender = userUpdateDto.Gender;
                user.Job = userUpdateDto.Job;
                user.Relation = userUpdateDto.Relation;
                _userDal.Update(user);
                return new SuccessResult("Bilgileriniz başarıyla güncellendi");
            }
            else
            {
                return new ErrorResult("Bir şeyler yanlış gitti");
            }
        }

        public IResult UpdateImage(User user)
        {
            if (user != null)
            {
                _userDal.Update(user);
                return new SuccessResult("Resim Yüklendi");
            }
            else
            {
                return new ErrorResult("Bir şeyler yanlış gitti");
            }
        }

        public IResult UpdateLocation(UserLocationDto userLocationDto)
        {
            var user = _userDal.Get(x => x.UserKey == userLocationDto.UserKey);
            if (user != null)
            {
                user.Lat = userLocationDto.Lat;
                user.Lng = userLocationDto.Lng;
                user.Province = userLocationDto.Province;
                _userDal.Update(user);
                return new SuccessResult("Konum bilgileriniz güncellendi");
            }
            else
            {
                return new ErrorResult("Birşeyler yanlış gitti");
            }
        }
    }
}
