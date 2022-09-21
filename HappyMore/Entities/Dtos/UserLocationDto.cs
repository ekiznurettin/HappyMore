using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserLocationDto
    {
        public string UserKey { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public string Province { get; set; }
    }
}
