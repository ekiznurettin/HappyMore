using Business.Abstract;
using Core.Utilities.Extensions;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using WebApi.Helpers.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;

        public UsersController(IUserService userService, IHttpContextAccessor contextAccessor, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, IWebHostEnvironment env)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
            _httpContextAccessor = httpContextAccessor;
            _imageHelper = imageHelper;
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        [HttpPost("index")]
        public IActionResult Index()
        {
            var results = _userService.GetAll();
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }

        [Authorize]
        [HttpPost("get-all-users")]
        public IActionResult GetAllUsersNotOwn(UserFilterDto userFilterDto)
        {
            var results = _userService.GetAllUsersByUserKey(userFilterDto);
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("get-all-users-with-mine")]
        public IActionResult GetAllUsers()
        {
            var results = _userService.GetAll();
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("get-user")]
        public IActionResult GetUser(UserMailDto userMailDto)
        {
            var results = _userService.GetUser(userMailDto.UserId);
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("get-user-by-key")]
        public IActionResult GetUserByUserKey(UserMailDto userMailDto)
        {
            var results = _userService.GetByUserKey(userMailDto.UserKey);
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("get-user-mail")]
        public IActionResult GetUserByMail(UserMailDto userMailDto)
        {
            var results = _userService.GetByMail(userMailDto.Mail);
            if (results.Success)
            {
                return Ok(results.Data);
            }
            return BadRequest("Başarısız");
        }
       [Authorize]
        [HttpPost("user-update")]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {

            var results = _userService.Update(userUpdateDto);
            if (results.Success)
            {
                return Ok(results.Message);
            }
            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("user-update-location")]
        public IActionResult UpdateUserLocation(UserLocationDto userLocationDto)
        {
            var results = _userService.UpdateLocation(userLocationDto);
            if (results.Success)
            {
                return Ok(results.Message);
            }
            return BadRequest("Başarısız");
        }

        [Authorize]
        [HttpPost("user-image-upload")]
        public IActionResult UploadUserImage(UserImageUploadDto userImageUploadDto)
        {
            bool isNewPictureUploaded = false;

            var oldUser = _userService.GetByUserKey(userImageUploadDto.UserKey);
            var oldUserPicture = oldUser.Data.ProfileImage;
            string ImageUrl = oldUserPicture;

            byte[] bytes = Convert.FromBase64String(userImageUploadDto.Image);
            Image image = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);

                if (image != null)
                {
                    if (!Directory.Exists($"{_wwwroot}/images/userImages/{userImageUploadDto.UserKey}"))
                    {
                        Directory.CreateDirectory($"{_wwwroot}/images/userImages/{userImageUploadDto.UserKey}");
                    }
                    ImageUrl = $"images/userImages/{userImageUploadDto.UserKey}/{userImageUploadDto.UserKey}_{DateTimeExtensions.FullDateAndTimeStringWithUndersCore(DateTime.Now)}.{userImageUploadDto.Extension}";
                    string path = $"{_wwwroot}/{ImageUrl}";
                    try
                    {
                        image.Save(path, ImageFormat.Png);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }


                    if (oldUser.Data.ProfileImage != "images/userImages/default.png")
                    {
                        isNewPictureUploaded = true;
                    }
                }
                else
                {
                    return BadRequest("Resim Seçilmedi");
                }
            }
            oldUser.Data.ProfileImage = ImageUrl;
            var result = _userService.UpdateImage(oldUser.Data);
            if (result.Success)
            {
                if (isNewPictureUploaded)
                {
                    _imageHelper.Delete(oldUserPicture);
                }
                return Ok(result.Message);
            }
            return BadRequest("Başarısız");
        }

            /*   [Authorize]
               [HttpPost("user-update-image")]
               public IActionResult UpdateUserImage(UserImageUploadDto userImageUploadDto)
               {
                   try
                   {
                       bool isNewPictureUploaded = false;
                       var userKey = Request.Query["userKey"].ToString();

                       var oldUser = _userService.GetByUserKey(userKey);
                       var oldUserPicture = oldUser.Data.ProfileImage;
                       string ImageUrl = oldUserPicture;

                       if (userImageUploadDto.ImageFile != null)
                       {
                           var uploadImageDtoResult = _imageHelper.Upload(userKey, userImageUploadDto.ImageFile, PictureType.User, userKey);
                           ImageUrl = uploadImageDtoResult.Success ? uploadImageDtoResult.Data.FullName : "images/userImages/default.png";
                           if (oldUser.Data.ProfileImage != "images/userImages/default.png")
                           {
                               isNewPictureUploaded = true;
                           }
                       }
                       else
                       {
                           return BadRequest("Resim Seçilmedi");
                       }
                       oldUser.Data.ProfileImage = ImageUrl;
                       var result = _userService.UpdateImage(oldUser.Data);
                       if (result.Success)
                       {
                           if (isNewPictureUploaded)
                           {
                               _imageHelper.Delete(oldUserPicture);
                           }
                           return Ok(result.Message);
                       }
                       return BadRequest("Başarısız");
                   }
                   catch (Exception ex)
                   {
                       return BadRequest(ex.Message);
                   }
               }*/

        }
}
