using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Place { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Status { get; set; }
        public DateTime PostDate{ get; set; }
        public User User { get; set; }
    }
}
