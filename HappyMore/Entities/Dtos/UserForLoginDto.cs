using Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
