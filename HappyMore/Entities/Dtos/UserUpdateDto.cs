using Entities.Abstract;

namespace Entities.Dtos
{
    public class UserUpdateDto:IDto
    {
        public string UserKey { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public int Gender { get; set; }
        public string Instagram { get; set; }
        public string Hobiler { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
        public int Relation { get; set; }
    }
}
