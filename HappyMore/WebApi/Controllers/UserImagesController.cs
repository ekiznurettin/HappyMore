using Business.Abstract;
using Core.Utilities.Extensions;
using Entities.Concrete;
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
    public class UserImagesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserImageService _userImageService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;

        public UserImagesController(IUserService userService, IUserImageService userImageService, IHttpContextAccessor contextAccessor, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, IWebHostEnvironment env)
        {
            _userService = userService;
            _userImageService = userImageService;
            _contextAccessor = contextAccessor;
            _httpContextAccessor = httpContextAccessor;
            _imageHelper = imageHelper;
            _env = env;
            _wwwroot = _env.WebRootPath; ;
        }

        [Authorize]
        [HttpPost("user-images-upload")]
        public IActionResult UploadUserImages(ImageListDto imageListDto)
        {
            string ImageUrl = "";
            byte[] bytes = Convert.FromBase64String(imageListDto.ImageUrl);
            Image image = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                if (image != null)
                {
                    if (!Directory.Exists($"{_wwwroot}/images/userImages/{imageListDto.UserKey}"))
                    {
                        Directory.CreateDirectory($"{_wwwroot}/images/userImages/{imageListDto.UserKey}");
                    }
                    ImageUrl = $"images/userImages/{imageListDto.UserKey}/{imageListDto.UserKey}_{DateTimeExtensions.FullDateAndTimeStringWithUndersCore(DateTime.Now)}.png";
                    string path = $"{_wwwroot}/{ImageUrl}";
                    try
                    {
                        image.Save(path, ImageFormat.Jpeg);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Resim Seçilmedi");
                }
            }

            UserImage userImage = new UserImage();
            userImage.CreatedDate = DateTime.Now;
            userImage.ImageUrl = ImageUrl;
            userImage.UserKey = imageListDto.UserKey;
            userImage.Status = 1;

            var result = _userImageService.Add(userImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest("Başarısız");
        }
        [Authorize]
        [HttpPost("user-images-delete")]
        public IActionResult DeleteImage(int Id)
        {
            var result = _userImageService.Delete(Id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("user-dene")]
        public IActionResult Deneme()
        {
          
                return Ok();
        }
        [Authorize]
        [HttpPost("get-all-user-photos")]
        public IActionResult GetAllUserPhotos(UserKeyDto userKeyDto)
        {
            var result = _userImageService.GetAllByUserKey(userKeyDto.UserKey);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
