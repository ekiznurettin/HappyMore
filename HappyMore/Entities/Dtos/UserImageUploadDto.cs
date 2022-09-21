using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserImageUploadDto
    {
        public string UserKey { get; set; }
        public string Image { get; set; }
        public string Extension { get; set; }
    }
}
