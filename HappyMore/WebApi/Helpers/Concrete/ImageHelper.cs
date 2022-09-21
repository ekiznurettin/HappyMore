using Core.Utilities.Extensions;
using Core.Utilities.Results;
using Entities.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.RegularExpressions;
using WebApi.Helpers.Abstract;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder = "images";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }
        public IDataResult<ImageUploadedDto> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName)
        {
            if (pictureType == PictureType.User)
            {
                folderName = userImagesFolder;
            }
            else if (pictureType == PictureType.Post)
            {
                folderName = postImagesFolder;
            }
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}/{name}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}/{name}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{DateTimeExtensions.FullDateAndTimeStringWithUndersCore(dateTime)}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}\\{imgFolder}\\{folderName}\\{name}", newFileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                pictureFile.CopyToAsync(stream);
            }
            return new SuccessDataResult<ImageUploadedDto>(new ImageUploadedDto
            {
                FullName = $"{imgFolder}/{folderName}/{name}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            if (pictureName != null)
            {
                var count = pictureName.Split('/').Length;
                var picture = pictureName.Split('/')[count - 1];
                string path = $"{_wwwroot}\\";
                for (int i = 0; i < count - 1; i++)
                {
                    path += (pictureName.Split('/')[i] + "\\");
                }
                var fileToDelete = Path.Combine($"{path}", picture);
                if (File.Exists(fileToDelete))
                {
                    var fileInfo = new FileInfo(fileToDelete);
                    var imageDeletedDto = new ImageDeletedDto
                    {
                        FullName = pictureName,
                        Extension = fileInfo.Extension,
                        Path = fileInfo.FullName,
                        Size = fileInfo.Length
                    };
                    File.Delete(fileToDelete);
                    return new SuccessDataResult<ImageDeletedDto>(imageDeletedDto, "Resim Silindi");
                }
            }
            return new ErrorDataResult<ImageDeletedDto>(null, "İşlem başarısız");
        }

    }
}
