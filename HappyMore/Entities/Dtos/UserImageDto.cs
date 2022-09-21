using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserImageDto
    {
        public string ImageUrl { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public int? Age{ get; set; }
    }
}
