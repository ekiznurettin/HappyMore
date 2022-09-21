using Entities.Abstract;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string UserKey { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string ProfileImage { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Bio { get; set; }
        public int? Gender { get; set; }
        public int? Relation { get; set; }
        public string Province { get; set; }
        public string Instagram { get; set; }
        public string Hobiler { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? IsGender { get; set; }
        public int? IsBio { get; set; }
        public int? IsPlace { get; set; }
        public int? Status { get; set; }
        public int? Age{ get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Job { get; set; }
    }
}
