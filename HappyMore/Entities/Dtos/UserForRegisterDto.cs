using Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string UserKey { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
    }
}
