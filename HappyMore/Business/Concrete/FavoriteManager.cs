using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private readonly IFavoriteDal _favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }

        public IResult Add(Favorite favorite)
        {
            var result = _favoriteDal.Get(a => a.Liking == favorite.Liking && a.Liked == favorite.Liked);
            if (result == null)
            {
                _favoriteDal.Add(favorite);
                return new SuccessResult("Success");
            }
            else
            {
                result.Liked = favorite.Liked;
                result.Liking = favorite.Liking;
                _favoriteDal.Update(result);
                return new SuccessResult("Success");
            }
        }

        public IResult Delete(string liking, string liked)
        {
            var result = _favoriteDal.Get(a => a.Liking == liking && a.Liked == liked);
            if (result != null)
            {
                _favoriteDal.Delete(result);
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }

        public IDataResult<Favorite> Get(string Liking, string liked)
        {
            var result = _favoriteDal.Get(a => a.Liked == Liking && a.Liked == liked);
            if (result != null)
            {
                return new SuccessDataResult<Favorite>(result, "Success");
            }
            else
            {
                return new ErrorDataResult<Favorite>(null, "Error");
            }
        }

        public IDataResult<IList<UserImageDto>> GetAllByUserKey(UserKeyDto userKeyDto)
        {
            var result = _favoriteDal.GetUsersWithFavorite(userKeyDto);
            if (result.Success)
            {
                return new SuccessDataResult<IList<UserImageDto>>(result.Data, "Success");
            }
            else
            {
                return new ErrorDataResult<IList<UserImageDto>>(null, "Error");
            }
        }
        public IResult Update(Favorite favorite)
        {
            var result = _favoriteDal.Get(a => a.Liking == favorite.Liking && a.Liked == favorite.Liked);
            if (result != null)
            {
                result.Liked = favorite.Liked;
                result.Liking = favorite.Liking;
                _favoriteDal.Update(result);
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
