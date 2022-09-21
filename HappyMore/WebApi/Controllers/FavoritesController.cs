using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [Authorize]
        [HttpPost("add-favorite")]
        public IActionResult AddFavorite(Favorite favorite)
        {
            var result = _favoriteService.Add(favorite);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("update-favorite")]
        public IActionResult UpdateFavorite(Favorite favorite)
        {
            var result = _favoriteService.Update(favorite);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("delete-favorite")]
        public IActionResult DeleteFavorite(Favorite favorite)
        {
            var result = _favoriteService.Delete(favorite.Liking, favorite.Liked);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("get-favorite")]
        public IActionResult GetFavorite(Favorite favorite)
        {
            var result = _favoriteService.Get(favorite.Liking,favorite.Liked);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("get-all-favorite")]
        public IActionResult GetAllFavorite(UserKeyDto userKeyDto)
        {
            var result = _favoriteService.GetAllByUserKey(userKeyDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
