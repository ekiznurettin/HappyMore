using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ImageListDto:IDto
    {
        public string UserKey { get; set; }
        public string ImageUrl { get; set; }
        public string Extension { get; set; }
    }
}
