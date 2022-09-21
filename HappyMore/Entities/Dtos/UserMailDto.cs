using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserMailDto
    {
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserKey { get; set; }
    }
}
