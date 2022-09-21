using Core.Utilities.Results;
using Entities.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Helpers.Abstract
{
    public interface IImageHelper
    {
        IDataResult<ImageUploadedDto> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
