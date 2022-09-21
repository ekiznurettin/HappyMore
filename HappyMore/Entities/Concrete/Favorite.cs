using Entities.Abstract;

namespace Entities.Concrete
{
    public class Favorite: IEntity
    {
        public int Id { get; set; }
        public string Liking { get; set; }
        public string Liked { get; set; }
    }
}
