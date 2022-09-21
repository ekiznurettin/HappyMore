using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class UserImage:IEntity
    {
        public int Id { get; set; }
        public string UserKey { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
